using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookmarking.Domain
{
    public class BookmarkRepository : Repository<Bookmark>, IBookmarkRepository
    {
        public override IEnumerable<Bookmark> GetAll()
        {
            return DataContext.Bookmarks;
        }

        public override Bookmark GetById(int id)
        {
            return DataContext.Bookmarks.Where(b => b.BookmarkId == id).SingleOrDefault();
        }

        public override void SaveOrUpdate(Bookmark item)
        {
            if (item.BookmarkId == 0)
                DataContext.Bookmarks.InsertOnSubmit(item);

            DataContext.SubmitChanges();
        }

        public override void Delete(Bookmark item)
        {
            DataContext.Bookmarks.DeleteOnSubmit(item);
            DataContext.SubmitChanges();
        }

        public Bookmark FindByUrl(string url)
        {
            return DataContext.Bookmarks.Where(b => b.Url == url).SingleOrDefault();
        }
    }
}