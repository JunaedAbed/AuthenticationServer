using AuthenticationServer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationServer.BLL.Services.UserRepositories
{
    public interface IUserRespository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);
        Task<User> CreateUser(User user);
    }
}
