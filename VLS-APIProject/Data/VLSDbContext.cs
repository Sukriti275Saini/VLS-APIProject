using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Data
{
    public class VLSDbContext : DbContext
    {
        private readonly IConfiguration config;

        public VLSDbContext(DbContextOptions<VLSDbContext> options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Record> Records { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("APIDatabase"));
        }


        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<User>()
                .HasData(new
                {
                    FirstName = "Sukriti",
                    LastName = "Saini",
                    UserName = "Saini275",
                    ProfilePicture = "https://i.pinimg.com/originals/a1/a9/f7/a1a9f7a7aff3637bb08b714cd8302da1.jpg",
                    DateOfBirth = new DateTime(1995, 05, 27),
                    Email = "sukriti.saini.275@gmail.com",
                    Password= "Saini@275",
                    Mobile = 8872283355,
                    Address = "Chandigarh"
                },
                new
                {
                    FirstName = "Sukriti",
                    LastName = "Saini",
                    UserName = "Sukriti275Saini",
                    ProfilePicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRoFhtthq6JsFEM5eAvoxEZu5E6nJkXSnbCwg&usqp=CAU",
                    DateOfBirth = new DateTime(1995, 05, 27),
                    Email = "sukriti275saini@gmail.com",
                    Password = "Saini@123",
                    Mobile = 9877672172,
                    Address = "Pathankot"
                });


            bldr.Entity<Video>()
                .HasData(new
                {
                    VideoId = 1,
                    VideoName = "Jumanji: The Next Level",
                    VideoImage = "https://thedigitalwise.com/wp-content/uploads/2019/05/574342dcd360ad1863624d310349fa94.jpg",
                    YearOfRelease = 2019,
                    Language = "English",
                    Director = "Jake Kasdan",
                    Actors = "Karen Gillan, Dwayne Johnson, Danny DeVito, Awkwafina",
                    Description = "When Spencer goes missing, the gang returns to Jumanji to travel unexplored territories and " +
                    "help their friend escape the world's most dangerous game.",
                    NoOfCopies = "12",
                    LeaseAmount = 100
                },
                new
                {
                    VideoId = 2,
                    VideoName = "Titanic",
                    VideoImage = "https://thedigitalwise.com/wp-content/uploads/2019/05/574342dcd360ad1863624d310349fa94.jpg",
                    YearOfRelease = 1997,
                    Language = "English, Hindi",
                    Director = "James Cameron",
                    Actors = "Kate Winslet, Leonardo DiCaprico",
                    Description = "Seventeen-year-old Rose hails from an aristocratic family and is set to be married. " +
                    "When she boards the Titanic, she meets Jack Dawson, an artist, and falls in love with him.",
                    NoOfCopies = "8",
                    LeaseAmount = 50
                },
                new
                {
                    VideoId = 3,
                    VideoName = "Cinderella",
                    VideoImage = "https://vignette.wikia.nocookie.net/disneyprincess/images/d/d3/Cinderella_2015_poster.png/revision/latest?cb=20200625134915",
                    YearOfRelease = 2015,
                    Language = "English",
                    Director = "Kenneth Branagh",
                    Actors = "Lily James, Richard Madden, Cate Blanchett, Helena Bonham Carter",
                    Description = "After the untimely death of her father, Ella is troubled by her stepmother and stepsisters. " +
                    "However, her life changes forever after dancing with a charming stranger at the Royal Ball.",
                    NoOfCopies = "5",
                    LeaseAmount = 75
                });


            bldr.Entity<Record>()
                .HasData(new
                {
                    RecordId = 1,
                    UserName = "Sukriti275Saini",
                    VideoId = 2,
                    IssueDate = new DateTime(2020, 07, 11),
                    ReturnDate = new DateTime(2020, 07, 21),
                    DueAmount = 50
                },
                new
                {
                    RecordId = 2,
                    UserName = "Saini275",
                    VideoId = 3,
                    IssueDate = new DateTime(2020, 07, 08),
                    ReturnDate = new DateTime(2020, 07, 18),
                    DueAmount = 100
                });
         
        }


    }
}
