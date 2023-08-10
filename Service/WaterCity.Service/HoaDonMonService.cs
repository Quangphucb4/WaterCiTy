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
using WaterCity.Core.Models.HoaDonMon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IHoaDonMonService))]
    public class HoaDonMonService : Base.Service, IHoaDonMonService
    {

        private readonly IHoaDonMonRepository _HoaDonMonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HoaDonMonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _HoaDonMonRepository = serviceProvider.GetRequiredService<IHoaDonMonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<HoaDonMonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _HoaDonMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<HoaDonMonEntity>)entities);
        }

        public Task<HoaDonMonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _HoaDonMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<HoaDonMonEntity> GetAllAsync()
        {
            var entities = _HoaDonMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<HoaDonMonEntity>)entities;
        }

        public HoaDonMonEntity GetByKeyIdAsync(string id)
        {
            var entity = _HoaDonMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(HoaDonMonModel model, CancellationToken cancellationToken = default)
        {
            if (_HoaDonMonRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonMon.HOADONMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HoaDonMonEntity>(model);
            _HoaDonMonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, HoaDonMonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _HoaDonMonRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonMon.HOADONMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _HoaDonMonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonMon.HOADONMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _HoaDonMonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _HoaDonMonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonMon.HOADONMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _HoaDonMonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
