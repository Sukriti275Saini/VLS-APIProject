﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VLS_APIProject.Data;

namespace VLS_APIProject.Migrations
{
    [DbContext(typeof(VLSDbContext))]
    partial class VLSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VLS_APIProject.Data.Entities.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DueAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            RecordId = 1,
                            DueAmount = 50,
                            IssueDate = new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Sukriti275Saini",
                            VideoId = 2
                        },
                        new
                        {
                            RecordId = 2,
                            DueAmount = 100,
                            IssueDate = new DateTime(2020, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Saini275",
                            VideoId = 3
                        });
                });

            modelBuilder.Entity("VLS_APIProject.Data.Entities.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserName = "Saini275",
                            Address = "Chandigarh",
                            DateOfBirth = new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sukriti.saini.275@gmail.com",
                            FirstName = "Sukriti",
                            LastName = "Saini",
                            Mobile = 8872283355L,
                            Password = "Saini@275",
                            ProfilePicture = "https://i.pinimg.com/originals/a1/a9/f7/a1a9f7a7aff3637bb08b714cd8302da1.jpg"
                        },
                        new
                        {
                            UserName = "Sukriti275Saini",
                            Address = "Pathankot",
                            DateOfBirth = new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sukriti275saini@gmail.com",
                            FirstName = "Sukriti",
                            LastName = "Saini",
                            Mobile = 9877672172L,
                            Password = "Saini@123",
                            ProfilePicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRoFhtthq6JsFEM5eAvoxEZu5E6nJkXSnbCwg&usqp=CAU"
                        });
                });

            modelBuilder.Entity("VLS_APIProject.Data.Entities.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaseAmount")
                        .HasColumnType("int");

                    b.Property<string>("NoOfCopies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("VideoId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            VideoId = 1,
                            Actors = "Karen Gillan, Dwayne Johnson, Danny DeVito, Awkwafina",
                            Description = "When Spencer goes missing, the gang returns to Jumanji to travel unexplored territories and help their friend escape the world's most dangerous game.",
                            Director = "Jake Kasdan",
                            Language = "English",
                            LeaseAmount = 100,
                            NoOfCopies = "12",
                            VideoImage = "https://thedigitalwise.com/wp-content/uploads/2019/05/574342dcd360ad1863624d310349fa94.jpg",
                            VideoName = "Jumanji: The Next Level",
                            YearOfRelease = 2019
                        },
                        new
                        {
                            VideoId = 2,
                            Actors = "Kate Winslet, Leonardo DiCaprico",
                            Description = "Seventeen-year-old Rose hails from an aristocratic family and is set to be married. When she boards the Titanic, she meets Jack Dawson, an artist, and falls in love with him.",
                            Director = "James Cameron",
                            Language = "English, Hindi",
                            LeaseAmount = 50,
                            NoOfCopies = "8",
                            VideoImage = "https://thedigitalwise.com/wp-content/uploads/2019/05/574342dcd360ad1863624d310349fa94.jpg",
                            VideoName = "Titanic",
                            YearOfRelease = 1997
                        },
                        new
                        {
                            VideoId = 3,
                            Actors = "Lily James, Richard Madden, Cate Blanchett, Helena Bonham Carter",
                            Description = "After the untimely death of her father, Ella is troubled by her stepmother and stepsisters. However, her life changes forever after dancing with a charming stranger at the Royal Ball.",
                            Director = "Kenneth Branagh",
                            Language = "English",
                            LeaseAmount = 75,
                            NoOfCopies = "5",
                            VideoImage = "https://vignette.wikia.nocookie.net/disneyprincess/images/d/d3/Cinderella_2015_poster.png/revision/latest?cb=20200625134915",
                            VideoName = "Cinderella",
                            YearOfRelease = 2015
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
