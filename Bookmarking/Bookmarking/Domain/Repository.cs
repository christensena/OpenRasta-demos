using System.Collections.Generic;

namespace Bookmarking.Domain
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly BookmarkStoreDataContext _dataContext;

        protected Repository()
        {
            _dataContext = new BookmarkStoreDataContext();
        }

        protected BookmarkStoreDataContext DataContext
        {
            get { return _dataContext; }
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);

        public abstract void SaveOrUpdate(T item);

        public abstract void Delete(T item);
    }
}