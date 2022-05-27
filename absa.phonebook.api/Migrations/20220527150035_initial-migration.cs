using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace absa.phonebook.api.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phonebooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    PhonebookId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Phonebooks_PhonebookId",
                        column: x => x.PhonebookId,
                        principalTable: "Phonebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Phonebooks",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("dca21998-eeab-4291-aae2-44a7b5e8ff03"), "General" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Name", "Number", "PhonebookId" },
                values: new object[,]
                {
                    { new Guid("25f097a4-ac24-40f7-9af5-150173cddfa9"), "Mom", "081-704-6758", new Guid("dca21998-eeab-4291-aae2-44a7b5e8ff03") },
                    { new Guid("02ec8615-8a3a-4dae-a1a5-7ffdbf2312df"), "Dad", "081-365-8532", new Guid("dca21998-eeab-4291-aae2-44a7b5e8ff03") },
                    { new Guid("6d19c635-0530-4868-a69b-5d40617057ad"), "Mr D", "011-342-1720", new Guid("dca21998-eeab-4291-aae2-44a7b5e8ff03") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PhonebookId",
                table: "Entries",
                column: "PhonebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Phonebooks");
        }
    }
}
