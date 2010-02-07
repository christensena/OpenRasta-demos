using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookmarking.Domain
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public override IEnumerable<User> GetAll()
        {
            return DataContext.Users;
        }

        public override User GetById(int id)
        {
            return DataContext.Users.Where(u => u.UserId == id).SingleOrDefault();
        }

        public override void SaveOrUpdate(User item)
        {
            if (item.UserId == 0)
                DataContext.Users.InsertOnSubmit(item);

            DataContext.SubmitChanges();
        }

        public override void Delete(User item)
        {
            DataContext.Users.DeleteOnSubmit(item);
            DataContext.SubmitChanges();
        }

        public User GetByUsername(string username)
        {
            return DataContext.Users.Where(u => u.Username == username).SingleOrDefault();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return DataContext.Users.Where(u => u.Username == username).SingleOrDefault();
        }

    }
}