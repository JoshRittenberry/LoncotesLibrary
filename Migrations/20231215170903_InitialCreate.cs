using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoncotesLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CheckoutDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialName = table.Column<string>(type: "text", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    OutOfCirculationSince = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    PatronId = table.Column<int>(type: "integer", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkouts_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Science Fiction" },
                    { 3, "Mystery" },
                    { 4, "Romance" },
                    { 5, "Thriller" },
                    { 6, "Historical Fiction" },
                    { 7, "Horror" },
                    { 8, "Biography/Autobiography" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "CheckoutDays", "Name" },
                values: new object[,]
                {
                    { 1, 7, "Book" },
                    { 2, 5, "CD" },
                    { 3, 2, "Periodical" },
                    { 4, 3, "DVD" },
                    { 5, 7, "Audiobook" }
                });

            migrationBuilder.InsertData(
                table: "Patrons",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 1, "456 Library St, Booktown, USA 12345", "alice.smith@email.com", "Alice", true, "Smith" },
                    { 2, "789 Reading Ave, Litville, USA 67890", "michael.johnson@email.com", "Michael", true, "Johnson" },
                    { 3, "101 Novel Rd, Storyville, USA 23456", "emily.brown@email.com", "Emily", true, "Brown" },
                    { 4, "202 Fable Dr, Narrativetown, USA 34567", "david.wilson@email.com", "David", false, "Wilson" },
                    { 5, "303 Tale Ct, Fictioncity, USA 45678", "sara.miller@email.com", "Sara", true, "Miller" },
                    { 6, "404 Legend Ln, Mythosburg, USA 56789", "james.davis@email.com", "James", false, "Davis" },
                    { 7, "505 Epic St, Fabulaville, USA 67890", "angela.garcia@email.com", "Angela", true, "Garcia" },
                    { 8, "606 Chronicle Ave, Allegorytown, USA 78901", "robert.martinez@email.com", "Robert", false, "Martinez" },
                    { 9, "707 Saga Pl, Prosetown, USA 89012", "lisa.hernandez@email.com", "Lisa", true, "Hernandez" },
                    { 10, "808 Narrative Rd, Storyburgh, USA 90123", "mark.lopez@email.com", "Mark", true, "Lopez" },
                    { 11, "909 Fable Blvd, Plotville, USA 01234", "sophia.lee@email.com", "Sophia", false, "Lee" },
                    { 12, "1010 Myth St, Genretown, USA 12345", "kevin.clark@email.com", "Kevin", true, "Clark" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "GenreId", "MaterialName", "MaterialTypeId", "OutOfCirculationSince" },
                values: new object[,]
                {
                    { 1, 6, "The Magic Mountain", 1, null },
                    { 2, 2, "Interstellar Soundtrack", 2, null },
                    { 3, 3, "Nature's Wonders", 3, null },
                    { 4, 2, "Inception", 4, null },
                    { 5, 6, "The Odyssey Audiobook", 5, null },
                    { 6, 1, "The Enchanted Forest", 1, null },
                    { 7, 2, "Science Today", 3, null },
                    { 8, 4, "Classical Melodies", 2, null },
                    { 9, 2, "Jurassic Park", 4, null },
                    { 10, 6, "To Kill a Mockingbird Audiobook", 5, null },
                    { 11, 2, "Galaxy Exploration", 1, null },
                    { 12, 3, "The Invisible Man", 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 4, "Beethoven's Symphony", 2, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 7, "Modern Art Today", 3, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, "The Matrix", 4, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 4, "Pride and Prejudice Audiobook", 5, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, "Dragon's Realm", 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 4, "Guitar Classics", 2, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, "Tech Innovations", 3, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 5, "Shawshank Redemption", 4, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 6, "The Great Gatsby Audiobook", 5, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, "Futuristic Visions", 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, "Murder on the Orient Express", 1, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 4, "Jazz Nights", 2, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 7, "Historical Review", 3, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 2, "Star Wars", 4, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 2, "1984 Audiobook", 5, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 1, "Alice in Wonderland", 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 4, "Opera Classics", 2, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 7, "World News Weekly", 3, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, "Harry Potter Series", 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Checkouts",
                columns: new[] { "Id", "CheckoutDate", "MaterialId", "PatronId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, null },
                    { 2, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, null },
                    { 3, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 3, null },
                    { 4, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, null },
                    { 5, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 5, null },
                    { 6, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 6, null },
                    { 7, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 7, null },
                    { 8, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 8, null },
                    { 9, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 9, null },
                    { 10, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 10, null },
                    { 11, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 11, null },
                    { 12, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 12, null },
                    { 13, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, null },
                    { 14, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2, null },
                    { 15, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 3, null },
                    { 16, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4, null },
                    { 17, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, null },
                    { 18, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 6, null },
                    { 19, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 7, null },
                    { 20, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 8, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12, new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 6, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 8, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 9, new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 10, new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 11, new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 12, new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 1, new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 2, new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 3, new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MaterialId",
                table: "Checkouts",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_GenreId",
                table: "Materials",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}
