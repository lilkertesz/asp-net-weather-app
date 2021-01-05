using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.WebSite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ID);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Observations");
        }
    }
}
