using System.Collections.Generic;
using System.Linq;
using Bookmarking.Domain;

namespace Bookmarking.Resources
{
    public class UserBookmarkListResource
    {
        public string Username { get; set; }
        public ICollection<UserBookmarkResource> BookmarkList { get; set; }

        public static UserBookmarkListResource Create(User user)
        {
            return new UserBookmarkListResource
                       {
                           Username = user.Username,
                           BookmarkList = user.UserBookmarks.Select(ub => UserBookmarkResource.Create(ub)).ToList()
                       };
        }
    }
}
