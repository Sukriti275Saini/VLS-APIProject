using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Models
{
    public class RecordModel
    {
        public int RecordId { get; set; }
        
        [Required]
        public User User { get; set; }

        [Required]
        public Video Video { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
