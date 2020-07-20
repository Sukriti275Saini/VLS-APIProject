using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VLS_APIProject.Data.Entities
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [Key]
        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        public long Mobile { get; set; }
        
        public string Address { get; set; }

    }
}
