using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;
using VLS_APIProject.Models;

namespace VLS_APIProject.Data
{
    public interface IUserRepository
    {

        LoginResponseModel Authenticate(LoginRequestModel model);

        public Task<User[]> GetAllUsers();

        public User GetByUserName(string UserName);

        public string LoginUser(string username, string Password);

        public UserResponseModel Add(User newUser);

        public User Delete(string UserName);

        public Task<bool> SaveChangesAsync();
    }
}
