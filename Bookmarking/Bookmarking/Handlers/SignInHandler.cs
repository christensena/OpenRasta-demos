using System;
using Bookmarking.Domain;
using Bookmarking.Resources;
using OpenRasta.Web;

namespace Bookmarking.Handlers
{
    public class SignInHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUriResolver _uriResolver;

        public SignInHandler(IUserRepository userRepository, IUriResolver uriResolver)
        {
            if (userRepository == null) throw new ArgumentNullException("userRepository");
            if (uriResolver == null) throw new ArgumentNullException("uriResolver");
            _userRepository = userRepository;
            _uriResolver = uriResolver;
        }

        public SignInResource Get()
        {
            return new SignInResource();
        }

        // TODO: use proper authentication or something
        public OperationResult Post(SignInResource signInCredentials)
        {
            var user = _userRepository.GetByUsernameAndPassword(signInCredentials.Login, signInCredentials.Password);
            if (user == null)
                return new OperationResult.Unauthorized() { RedirectLocation = _uriResolver.CreateUriFor(signInCredentials) };

            var userResource = new UserResource { Username = user.Username };
            return new OperationResult.SeeOther { RedirectLocation = _uriResolver.CreateUriFor(userResource) };
        }
    }
}