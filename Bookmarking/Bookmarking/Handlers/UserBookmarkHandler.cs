using Bookmarking.Resources;
using OpenRasta.Web;
using System;
namespace Bookmarking.Handlers
{
    public class UserBookmarkHandler
    {
        public CreateUserBookmarkResource Get(string username)
        {
            // TODO: validate username
            return new CreateUserBookmarkResource { Username = username };
        }

        public OperationResult Get(string username, int bookmarkId)
        {
            throw new NotImplementedException();
        }

        public OperationResult Post(string username, UserBookmarkResource userBookmarkResource)
        {
            throw new NotImplementedException();
        }

        public OperationResult Post(string username, int bookmarkId)
        {
            throw new NotImplementedException();
        }

    }
}