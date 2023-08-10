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
using WaterCity.Core.Models.CTHDMon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ICTHDMonService))]
    public class CTHDMonService : Base.Service, ICTHDMonService
    {

        private readonly ICTHDMonRepository _CTHDMonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public CTHDMonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _CTHDMonRepository = serviceProvider.GetRequiredService<ICTHDMonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<CTHDMonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _CTHDMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<CTHDMonEntity>)entities);
        }

        public Task<CTHDMonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _CTHDMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<CTHDMonEntity> GetAllAsync()
        {
            var entities = _CTHDMonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<CTHDMonEntity>)entities;
        }

        public CTHDMonEntity GetByKeyIdAsync(string id)
        {
            var entity = _CTHDMonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(CTHDMonModel model, CancellationToken cancellationToken = default)
        {
            if (_CTHDMonRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsCTHDMon.CTHDMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<CTHDMonEntity>(model);
            _CTHDMonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, CTHDMonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _CTHDMonRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsCTHDMon.CTHDMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _CTHDMonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsCTHDMon.CTHDMON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _CTHDMonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _CTHDMonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsCTHDMon.CTHDMON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _CTHDMonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
