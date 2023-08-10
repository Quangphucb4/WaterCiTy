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
using WaterCity.Core.Models.LoaiMon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ILoaiMonService))]
    public class LoaiMonService : Base.Service, ILoaiMonService
    {

        private readonly ILoaiMonRepository _LoaiMonRepository;
        private readonly IMapper _mapper;
        Serilog.ILogger _logger;

        public LoaiMonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _LoaiMonRepository = serviceProvider.GetRequiredService<ILoaiMonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LoaiMonModel model, CancellationToken cancellationToken = default)
        {
            if (_LoaiMonRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiMon.LOAIMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LoaiMonEntity>(model);
            _LoaiMonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _LoaiMonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiMon.LOAIMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _LoaiMonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<LoaiMonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _LoaiMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<LoaiMonEntity>)entities);
        }

        public Task<LoaiMonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _LoaiMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<LoaiMonEntity> GetAllAsync()
        {
            var entities = _LoaiMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<LoaiMonEntity>)entities;
        }

        public LoaiMonEntity GetByKeyIdAsync(string id)
        {
            var entity = _LoaiMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, LoaiMonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _LoaiMonRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiMon.LOAIMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _LoaiMonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiMon.LOAIMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _LoaiMonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
