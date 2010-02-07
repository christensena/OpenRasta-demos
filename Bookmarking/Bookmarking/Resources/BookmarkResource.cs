using Bookmarking.Domain;

namespace Bookmarking.Resources
{
    public class BookmarkResource
    {
        public string Url { get; set; }
        public string Title { get; set; }

        public static BookmarkResource Create(Bookmark bookmark)
        {
            return new BookmarkResource
                       {
                           Url = bookmark.Url,
                           Title = bookmark.Title
                       };
        }
    }
}