using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.LopHoc;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ILopHocService))]
    public class LopHocService : Base.Service, ILopHocService
    {

        private readonly ILopHocRepository _LopHocRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LopHocService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _LopHocRepository = serviceProvider.GetRequiredService<ILopHocRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<LopHocEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _LopHocRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<LopHocEntity>)entities);
        }

        public Task<LopHocEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _LopHocRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<LopHocEntity> GetAllAsync()
        {
            var entities = _LopHocRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<LopHocEntity>)entities;
        }

        public LopHocEntity GetByKeyIdAsync(string id)
        {
            var entity = _LopHocRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(LopHocModel model, CancellationToken cancellationToken = default)
        {
            if (_LopHocRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLopHoc.LOPHOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LopHocEntity>(model);
            _LopHocRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, LopHocModel model, CancellationToken cancellationToken = default)
        {
            var entity = _LopHocRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLopHoc.LOPHOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _LopHocRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLopHoc.LOPHOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _LopHocRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _LopHocRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLopHoc.LOPHOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _LopHocRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
