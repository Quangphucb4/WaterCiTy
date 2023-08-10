﻿using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IXaRepository))]
    public class XaRepository : Repository<XaEntity>, IXaRepository
    {
        public XaRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

