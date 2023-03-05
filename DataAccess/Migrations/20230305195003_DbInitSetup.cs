using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DbInitSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", precision: 14, scale: 2, nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstates_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Birthday", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Іван", "Іваненко", "Сергійович" },
                    { 2, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрій", "Садовий", "Петрович" },
                    { 3, new DateTime(1962, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петро", "Гриценко", "Валерійович" },
                    { 4, new DateTime(1992, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ірина", "Кучор", "Валентинівна" },
                    { 5, new DateTime(1980, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Оля", "Іваненко", "Володимирів" },
                    { 6, new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Василина", "Зінченко", "Володимирівна" }
                });

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Id", "Address", "Cost", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Ukraine, Ternopil, str. Dovjenka 10/2", 40000m, "Avalon Number 1", 1 },
                    { 2, "Ukraine, Ternopil, str. Dovjenka 10/3", 42000m, "Avalon Number 1", 1 },
                    { 3, "Ukraine, Lviv, str. Freedom 5/25", 50000m, "New Britain", 2 },
                    { 4, "Ukraine, Kyiv, str. Central 31/7", 35000m, "Holland", 3 },
                    { 5, "Ukraine, Uzhorod, str. Iv.Franka 2/6", 32000m, "Sultan Palace", 3 },
                    { 6, "Ukraine, Kharkiv, str. Sumska 15/1", 41000m, "American Square", 4 },
                    { 7, "Ukraine, Lviv, str. Zelena 11/4", 47000m, "Viking Building", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_OwnerId",
                table: "RealEstates",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
