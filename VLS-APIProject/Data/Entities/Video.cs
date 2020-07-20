using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VLS_APIProject.Data.Entities
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

        public string VideoName { get; set; }

        public string VideoImage { get; set; }

        [Range(1900, 2020)]
        public int YearOfRelease { get; set; }

        public string Language { get; set; }

        public string Director { get; set; }

        public string Actors { get; set; }

        public string Description { get; set; }

        [Range(2, 25)]
        public string NoOfCopies { get; set; }

        public int LeaseAmount { get; set; }

    }
}
