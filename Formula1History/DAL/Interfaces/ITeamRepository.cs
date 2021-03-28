using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITeamRepository<T> : IGenericRepository<T>
        where T : class
    {
        Task<T> GetTeamAsync(Guid id, Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllTeamsAsync(Expression<Func<T, string>> predicate);
    }
}