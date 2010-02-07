using System;
using System.Collections.Generic;
using System.Linq;
using Bookmarking.Domain;

namespace Bookmarking.Resources
{
    public class UserResource
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<UserBookmarkResource> LatestBookmarks { get; set; }

        public static UserResource Create(User user)
        {
            return new UserResource
                       {
                           Username = user.Username,
                           DisplayName = user.DisplayName,
                           EmailAddress = user.EmailAddress,
                           LatestBookmarks = user.UserBookmarks.Select(ub => UserBookmarkResource.Create(ub)).ToList()
                       };
        }
    }
}