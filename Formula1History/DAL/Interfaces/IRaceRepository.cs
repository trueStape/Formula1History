using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities.Race;

namespace DAL.Interfaces
{
    public interface IRaceRepository<T> : IGenericRepository<T>
        where T : class
    {
        Task<T> GetRaceAsync(Guid id, Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllRaceAsync(Expression<Func<T, string>> predicate);
    }
}