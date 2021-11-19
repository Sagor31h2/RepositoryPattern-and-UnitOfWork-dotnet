using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pocketBook.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        //The Task<TResult> class represents a single operation that returns a value and that usually executes asynchronously
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
    }
}