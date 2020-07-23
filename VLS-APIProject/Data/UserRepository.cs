using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;
using VLS_APIProject.Helpers;
using VLS_APIProject.Models;

namespace VLS_APIProject.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly VLSDbContext db;
        private readonly AppSettings appSettings;

        public UserRepository(VLSDbContext db, IOptions<AppSettings> appSettings)
        {
            this.db = db;
            this.appSettings = appSettings.Value;
        }

        public LoginResponseModel Authenticate(LoginRequestModel model)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new LoginResponseModel(user, token);
        }


        public async Task<User[]> GetAllUsers()
        {
            IQueryable<User> allusers = from user in db.Users
                                        orderby user.FirstName
                                        select user;
            return await allusers.ToArrayAsync();
        }


        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public User GetByUserName(string UserName)
        {
            //IQueryable<User> user = from u in db.Users
            //                      where u.UserName.StartsWith(UserName) || string.IsNullOrEmpty(UserName)
            //                    select u;
            //return await user.FirstOrDefaultAsync();
            return db.Users.Find(UserName);
        }

        public string LoginUser(string username, string Password)
        {
            var checkuser = GetByUserName(username);
            if (checkuser != null)
            {
                var result = checkuser.Password.Equals(Password);
                if (!result)
                {
                    return "Incorrect Password";
                }
                return "Successfull";
            }
            return "Username not found";

        }

        public UserResponseModel Add(User newUser)
        {
            var checkusername = from usr in db.Users
                                where usr.UserName.Equals(newUser.UserName)
                                select usr;
            if (checkusername.Count() > 0)
            {
                return null;
            }
            db.Add(newUser);

            var token = generateJwtToken(newUser);

            return new UserResponseModel(newUser, token);
        }

        public User Delete(string UserName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await db.SaveChangesAsync()) > 0;
        }
    }
}
