using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VLS_APIProject.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }

        public string VideoName { get; set; }

        public string VideoImage { get; set; }

        public int YearOfRelease { get; set; }

        public string Language { get; set; }

        public string Director { get; set; }

        public string Actors { get; set; }

        public string Description { get; set; }

        public string NoOfCopies { get; set; }

        public int LeaseAmount { get; set; }
    }
}
