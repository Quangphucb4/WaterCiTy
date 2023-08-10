﻿using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IChiSoDongHoRepository))]
    public class ChiSoDongHoRepository : Repository<ChiSoDongHoEntity>, IChiSoDongHoRepository
    {
        public ChiSoDongHoRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
