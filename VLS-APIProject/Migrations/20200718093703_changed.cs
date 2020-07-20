using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VLS_APIProject.Migrations
{
    public partial class changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "Saini275Saini");

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "DueAmount", "IssueDate", "ReturnDate", "UserName", "VideoId" },
                values: new object[] { 2, 100, new DateTime(2020, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saini275", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "Mobile", "Password", "ProfilePicture" },
                values: new object[] { "Sukriti275Saini", "Pathankot", new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "sukriti275saini@gmail.com", "Sukriti", "Saini", 9877672172L, "Saini@123", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRoFhtthq6JsFEM5eAvoxEZu5E6nJkXSnbCwg&usqp=CAU" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "DueAmount", "IssueDate", "ReturnDate", "UserName", "VideoId" },
                values: new object[] { 1, 50, new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sukriti275Saini", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "Sukriti275Saini");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "Mobile", "Password", "ProfilePicture" },
                values: new object[] { "Saini275Saini", "Pathankot", new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "sukriti275saini@gmail.com", "Sukriti", "Saini", 9877672172L, "Saini@123", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRoFhtthq6JsFEM5eAvoxEZu5E6nJkXSnbCwg&usqp=CAU" });
        }
    }
}
