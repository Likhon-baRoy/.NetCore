using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReceiveNewsLetters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryName" },
                values: new object[,]
                {
                    { new Guid("1f7294c7-940a-423d-b5c1-d09d8caf0c19"), "Canada" },
                    { new Guid("43d44ee4-0f3b-4a57-8aa3-fa7900494fa3"), "India" },
                    { new Guid("4c83e5bb-df23-49d2-8d0a-e7616d336564"), "UK" },
                    { new Guid("a4d39121-5788-4fa5-8e14-fe3781617862"), "Bangladesh" },
                    { new Guid("c780c999-8945-480d-ab02-3c0d2c0836d6"), "USA" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonID", "Address", "CountryID", "DateOfBirth", "Email", "Gender", "PersonName", "ReceiveNewsLetters" },
                values: new object[,]
                {
                    { new Guid("0b3b2afd-dd72-4656-930b-02696ae1809b"), "1 Cordelia Junction", new Guid("1f7294c7-940a-423d-b5c1-d09d8caf0c19"), new DateTime(1994, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "efroome8@yandex.ru", "Female", "Elyssa", false },
                    { new Guid("33f2c278-20e3-448a-a501-042f31571012"), "56945 Dennis Road", new Guid("43d44ee4-0f3b-4a57-8aa3-fa7900494fa3"), new DateTime(1995, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfrye5@epa.gov", "Male", "Davey", true },
                    { new Guid("37faf028-80b3-4471-8201-49b742e2f384"), "9367 Burrows Place", new Guid("c780c999-8945-480d-ab02-3c0d2c0836d6"), new DateTime(2000, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "kgilbart0@privacy.gov.au", "Female", "Kate", false },
                    { new Guid("59e3a9e6-07cd-4205-8b49-1a12418cef5f"), "7397 Elmside Parkway", new Guid("4c83e5bb-df23-49d2-8d0a-e7616d336564"), new DateTime(1994, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ffrow7@marketwatch.com", "Male", "Flinn", true },
                    { new Guid("66ec3051-1d0b-4434-9bc8-2ed833503f9b"), "86 Leroy Trail", new Guid("a4d39121-5788-4fa5-8e14-fe3781617862"), new DateTime(1997, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "elaxtonne6@ihg.com", "Male", "Earl", true },
                    { new Guid("7601b84c-5187-45fb-9090-59e44fced8a9"), "5 Rowland Parkway", new Guid("c780c999-8945-480d-ab02-3c0d2c0836d6"), new DateTime(1994, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewandena@reddit.com", "Female", "Ettie", false },
                    { new Guid("b6478104-7ff7-4f12-a22a-657d77db5bff"), "62359 Veith Point", new Guid("1f7294c7-940a-423d-b5c1-d09d8caf0c19"), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "lthickens1@nifty.com", "Male", "Linoel", true },
                    { new Guid("ea268eaa-b13a-4dee-8c20-79270ec7803e"), "5 Crowley Circle", new Guid("a4d39121-5788-4fa5-8e14-fe3781617862"), new DateTime(1995, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "agumary3@hubpages.com", "Female", "Agnella", false },
                    { new Guid("eaf29c21-76f5-430d-b38f-c903d8c0fc1c"), "91217 Sycamore Circle", new Guid("43d44ee4-0f3b-4a57-8aa3-fa7900494fa3"), new DateTime(1999, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "cgrafton4@squarespace.com", "Female", "Courtney", true },
                    { new Guid("f47f89c5-98a4-48b3-b2d1-7909758578a7"), "948 Summer Ridge Circle", new Guid("4c83e5bb-df23-49d2-8d0a-e7616d336564"), new DateTime(1990, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "skix2@fotki.com", "Female", "Sonya", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
