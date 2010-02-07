using System.Collections.Generic;

namespace Bookmarking.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        User GetByUsernameAndPassword(string username, string password);
    }
}