using Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class InitialDiagnosisKeyCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "DiagnosisKeys",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   DailyKey = table.Column<string>(maxLength: 128, nullable: true),
                   DiagnosisId = table.Column<int>(nullable: false),
                   Date = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DiagnosisKeys", x => x.Id);
                  
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosisKeys");
        }
    }
}
