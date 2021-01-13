using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "ID", "City", "Description", "Latitude", "Longitude", "TimeStamp", "UserName" },
                values: new object[] { 1L, null, "It is very hot and sunny here", 47.49973, 19.05508, new DateTime(2020, 11, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), "User" });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "ID", "City", "Description", "Latitude", "Longitude", "TimeStamp", "UserName" },
                values: new object[] { 2L, null, "Freezing cold", 47.49973, 19.05508, new DateTime(2020, 10, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), "Jane" });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "ID", "City", "Description", "Latitude", "Longitude", "TimeStamp", "UserName" },
                values: new object[] { 3L, null, "Beach time!", 40.419559999999997, -3.6919599999999999, new DateTime(2020, 6, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), "Pablo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");
        }
    }
}
