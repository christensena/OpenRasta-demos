using System.Linq;
using Bookmarking.Domain;

namespace Bookmarking.Resources
{
    public class UserBookmarkResource
    {
        public int BookmarkId { get; set; }
        public string Username { get; set; }
        public string PageUrl { get; set; }
        public string PageTitle { get; set; }
        public string Tags { get; set; }

        public static UserBookmarkResource Create(UserBookmark userBookmark)
        {
            var tags = userBookmark.UserBookmarkTags.Select(ubt => ubt.Tag);

            return new UserBookmarkResource
                       {
                           Username = userBookmark.User.Username,
                           PageUrl = userBookmark.Bookmark.Url,
                           PageTitle = string.IsNullOrEmpty(userBookmark.CustomTitle) ? userBookmark.Bookmark.Title : userBookmark.CustomTitle,
                           Tags = string.Join(" ", tags.ToArray())
                       };
        }
    }
}