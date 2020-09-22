using PocJWT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocJWT.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User Get(string username, string password);
    }
}
