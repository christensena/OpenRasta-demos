using System.Collections.Generic;

namespace Bookmarking.Resources
{
    public class HomeResource
    {
        public ICollection<BookmarkResource> LatestBookmarks { get; set; }
    }
}