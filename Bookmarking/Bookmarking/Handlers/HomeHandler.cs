using System;
using System.Linq;
using Bookmarking.Domain;
using Bookmarking.Resources;

namespace Bookmarking.Handlers
{
    public class HomeHandler
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public HomeHandler(IBookmarkRepository bookmarkRepository)
        {
            if (bookmarkRepository == null) throw new ArgumentNullException("bookmarkRepository");
            _bookmarkRepository = bookmarkRepository;
        }

        public HomeResource Get()
        {
            var bookmarks = _bookmarkRepository.GetAll();

            var latestBookmarks = bookmarks.Select(
                bookmark => BookmarkResource.Create(bookmark)).ToList();

            return new HomeResource { LatestBookmarks = latestBookmarks };
        }
    }
}