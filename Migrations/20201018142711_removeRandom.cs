using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNET_Chat_Server.Migrations
{
    public partial class removeRandom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RandomModels",
                columns: new[] { "Id", "Name", "Number" },
                values: new object[] { new Guid("7a7f8f9c-4647-4db5-b564-d0097caf5c18"), "a", 5 });
        }
    }
}
