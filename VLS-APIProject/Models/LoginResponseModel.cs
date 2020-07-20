using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Models
{
    public class LoginResponseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public string Address { get; set; }

        public string Token { get; set; }

        
        public LoginResponseModel(User user, string token)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Password = user.Password;
            ProfilePicture = user.ProfilePicture;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
            Mobile = user.Mobile;
            Address = user.Address;
            Token = token;

        }
    }
}
