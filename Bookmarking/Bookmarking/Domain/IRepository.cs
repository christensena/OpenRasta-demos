using System.Collections.Generic;

namespace Bookmarking.Domain
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void SaveOrUpdate(T item);
        void Delete(T item);
    }
}