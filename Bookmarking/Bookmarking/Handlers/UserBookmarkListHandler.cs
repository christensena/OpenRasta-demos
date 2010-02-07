using System;
using System.Linq;
using Bookmarking.Domain;
using Bookmarking.Resources;
using OpenRasta.Web;

namespace Bookmarking.Handlers
{
    public class UserBookmarkListHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUriResolver _uriResolver;

        public UserBookmarkListHandler(IUserRepository userRepository, IBookmarkRepository bookmarkRepository, IUriResolver uriResolver)
        {
            if (userRepository == null) throw new ArgumentNullException("userRepository");
            if (bookmarkRepository == null) throw new ArgumentNullException("bookmarkRepository");
            if (uriResolver == null) throw new ArgumentNullException("uriResolver");
            _userRepository = userRepository;
            _bookmarkRepository = bookmarkRepository;
            _uriResolver = uriResolver;
        }

        public OperationResult Get(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null)
                return new OperationResult.NotFound {Description = "User not found with username: " + username};

            return new OperationResult.OK { ResponseResource = UserBookmarkListResource.Create(user) };
        }

        // TODO: move most of this and similar business/domain logic heavy bits into separate service class(es)
        // TODO: look at this, linq2sql is crap, switch to nhibernate or something
        public OperationResult Post(string username, CreateUserBookmarkResource userBookmarkResource)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null)
                return new OperationResult.NotFound { Description = "User not found with username: " + username };

            var bookmark = _bookmarkRepository.FindByUrl(userBookmarkResource.PageUrl);
            if (bookmark == null)
            {
                bookmark = new Bookmark
                               {
                                   Title = userBookmarkResource.PageTitle,
                                   Url = userBookmarkResource.PageUrl
                               };
                _bookmarkRepository.SaveOrUpdate(bookmark);
            }

            var userBookmark = new UserBookmark
                                   {
                                       Bookmark = bookmark,
                                       User = user,
                                   };

            foreach (var tag in userBookmarkResource.Tags.Split(' '))
            {
                userBookmark.UserBookmarkTags.Add(new UserBookmarkTag {Tag = tag.Trim(), UserBookmark = userBookmark});
            }

            user.UserBookmarks.Add(userBookmark);

            _userRepository.SaveOrUpdate(user);

            return new OperationResult.SeeOther
                       {
                           RedirectLocation = _uriResolver.CreateUriFor(new UserResource {Username = username})
                       };
        }
    }
}