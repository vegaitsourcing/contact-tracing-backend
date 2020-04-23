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
                   HealthID = table.Column<string>(maxLength: 50, nullable: false),
                   DailyKey = table.Column<string>(maxLength: 128, nullable: true),
                   Sent = table.Column<bool>(nullable: false),
                   Confirmed = table.Column<bool>(nullable: false),
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
