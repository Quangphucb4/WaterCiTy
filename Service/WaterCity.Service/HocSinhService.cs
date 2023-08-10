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
using WaterCity.Core.Models.HocSinh;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IHocSinhService))]
    public class HocSinhService : Base.Service, IHocSinhService
    {

        private readonly IHocSinhRepository _HocSinhRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HocSinhService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _HocSinhRepository = serviceProvider.GetRequiredService<IHocSinhRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<HocSinhEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _HocSinhRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<HocSinhEntity>)entities);
        }

        public Task<HocSinhEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _HocSinhRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<HocSinhEntity> GetAllAsync()
        {
            var entities = _HocSinhRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<HocSinhEntity>)entities;
        }

        public HocSinhEntity GetByKeyIdAsync(string id)
        {
            var entity = _HocSinhRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(HocSinhModel model, CancellationToken cancellationToken = default)
        {
            if (_HocSinhRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHocSinh.HOCSINH_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HocSinhEntity>(model);
            _HocSinhRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, HocSinhModel model, CancellationToken cancellationToken = default)
        {
            var entity = _HocSinhRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHocSinh.HOCSINH_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _HocSinhRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHocSinh.HOCSINH_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _HocSinhRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _HocSinhRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHocSinh.HOCSINH_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _HocSinhRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
