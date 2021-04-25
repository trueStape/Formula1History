using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities.Team;

namespace DAL.Interfaces
{
    public interface ITeamRepository<T> : IGenericRepository<T>
        where T : class
    {
        Task<T> GetTeamAsync(Guid id, Expression<Func<T, bool>> predicate);
        Task<List<TeamEntity>> GetAllTeamsAsync(Expression<Func<TeamEntity, string>> predicate);
    }
}