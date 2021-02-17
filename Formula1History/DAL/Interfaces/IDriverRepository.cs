using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities.Peoples;

namespace DAL.Interfaces
{
    public interface IDriverRepository : IGenericRepository<DriverEntity>, IPeople<DriverEntity>
    {

    }
}