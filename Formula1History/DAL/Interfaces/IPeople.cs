using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities.Peoples;

namespace DAL.Interfaces
{
    public interface IPeople<T>
        where T : class
    {
        Task<T> GetPeopleAsync(Guid id, Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllPeopleAsync(Expression<Func<T, string>> predicate);
    }
}