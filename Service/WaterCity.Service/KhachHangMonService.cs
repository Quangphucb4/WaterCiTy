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
using WaterCity.Core.Models.KhachHangMon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IKhachHangMonService))]
    public class KhachHangMonService : Base.Service, IKhachHangMonService
    {

        private readonly IKhachHangMonRepository _KhachHangMonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhachHangMonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _KhachHangMonRepository = serviceProvider.GetRequiredService<IKhachHangMonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<KhachHangMonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _KhachHangMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<KhachHangMonEntity>)entities);
        }

        public Task<KhachHangMonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _KhachHangMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<KhachHangMonEntity> GetAllAsync()
        {
            var entities = _KhachHangMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<KhachHangMonEntity>)entities;
        }

        public KhachHangMonEntity GetByKeyIdAsync(string id)
        {
            var entity = _KhachHangMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(KhachHangMonModel model, CancellationToken cancellationToken = default)
        {
            if (_KhachHangMonRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHangMon.KHACHHANGMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhachHangMonEntity>(model);
            _KhachHangMonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, KhachHangMonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _KhachHangMonRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHangMon.KHACHHANGMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _KhachHangMonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHangMon.KHACHHANGMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _KhachHangMonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _KhachHangMonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHangMon.KHACHHANGMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _KhachHangMonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
