﻿using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ILopHocRepository))]
    public class LopHocRepository : Repository<LopHocEntity>, ILopHocRepository
    {
        public LopHocRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

