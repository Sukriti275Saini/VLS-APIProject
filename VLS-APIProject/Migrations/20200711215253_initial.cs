using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VLS_APIProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mobile = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoName = table.Column<string>(nullable: true),
                    VideoImage = table.Column<string>(nullable: true),
                    YearOfRelease = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Actors = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NoOfCopies = table.Column<string>(nullable: true),
                    LeaseAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    VideoId = table.Column<int>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    DueAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Records_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "Mobile", "Password", "ProfilePicture" },
                values: new object[,]
                {
                    { "Saini275", "Chandigarh", new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "sukriti.saini.275@gmail.com", "Sukriti", "Saini", 8872283355L, "Saini@275", "https://i.pinimg.com/originals/a1/a9/f7/a1a9f7a7aff3637bb08b714cd8302da1.jpg" },
                    { "Saini275Saini", "Pathankot", new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "sukriti275saini@gmail.com", "Sukriti", "Saini", 9877672172L, "Saini@123", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRoFhtthq6JsFEM5eAvoxEZu5E6nJkXSnbCwg&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "Actors", "Description", "Director", "Language", "LeaseAmount", "NoOfCopies", "VideoImage", "VideoName", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, "Karen Gillan, Dwayne Johnson, Danny DeVito, Awkwafina", "When Spencer goes missing, the gang returns to Jumanji to travel unexplored territories and help their friend escape the world's most dangerous game.", "Jake Kasdan", "English", 100, "12", "https://thedigitalwise.com/wp-content/uploads/2019/05/574342dcd360ad1863624d310349fa94.jpg", "Jumanji: The Next Level", 2019 },
                    { 2, "Kate Winslet, Leonardo DiCaprico", "Seventeen-year-old Rose hails from an aristocratic family and is set to be married. When she boards the Titanic, she meets Jack Dawson, an artist, and falls in love with him.", "James Cameron", "English, Hindi", 50, "8", "https://thedigitalwise.com/wp-content/uploads/2019/05/574342dcd360ad1863624d310349fa94.jpg", "Titanic", 1997 },
                    { 3, "Lily James, Richard Madden, Cate Blanchett, Helena Bonham Carter", "After the untimely death of her father, Ella is troubled by her stepmother and stepsisters. However, her life changes forever after dancing with a charming stranger at the Royal Ball.", "Kenneth Branagh", "English", 75, "5", "https://vignette.wikia.nocookie.net/disneyprincess/images/d/d3/Cinderella_2015_poster.png/revision/latest?cb=20200625134915", "Cinderella", 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserName",
                table: "Records",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VideoId",
                table: "Records",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
