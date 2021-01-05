using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.WebSite.Migrations
{
    public partial class CorrectedObservationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "ID", "City", "Description", "TimeStamp", "UserName" },
                values: new object[] { 1L, "Budapest", "It is very hot and sunny here", new DateTime(2020, 11, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), "User" });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "ID", "City", "Description", "TimeStamp", "UserName" },
                values: new object[] { 2L, "Budapest", "Freezing cold", new DateTime(2020, 10, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), "Jane" });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "ID", "City", "Description", "TimeStamp", "UserName" },
                values: new object[] { 3L, "Madrid", "Beach time!", new DateTime(2020, 6, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), "Pablo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "City", "Country", "CountryCode", "State" },
                values: new object[] { 1L, "Budapest", null, null, null });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "City", "Country", "CountryCode", "State" },
                values: new object[] { 2L, "Budapest", null, null, null });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "City", "Country", "CountryCode", "State" },
                values: new object[] { 3L, "Madrid", null, null, null });
        }
    }
}
