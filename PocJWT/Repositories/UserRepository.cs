using PocJWT.Model;
using PocJWT.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PocJWT.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "leticia", Password = "123", Role = "TI" });
            users.Add(new User { Id = 2, UserName = "martins", Password = "321", Role = "Admin" });
            return users.Where(x => x.Password == password && x.UserName.ToLower() == username.ToLower()).FirstOrDefault();
        }
    }
}
