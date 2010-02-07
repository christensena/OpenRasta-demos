using System;
using System.Linq;
using Bookmarking.Domain;
using Bookmarking.Resources;
using OpenRasta.Web;

namespace Bookmarking.Handlers
{
    public class UserHandler
    {
        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            if (userRepository == null) throw new ArgumentNullException("userRepository");
            _userRepository = userRepository;
        }

        public OperationResult Get(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null)
                return new OperationResult.NotFound() { Description = "User not found." };

            return new OperationResult.OK { ResponseResource = UserResource.Create(user) };
        }
    }
}