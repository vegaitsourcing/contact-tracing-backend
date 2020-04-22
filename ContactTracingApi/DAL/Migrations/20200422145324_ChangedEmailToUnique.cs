using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangedEmailToUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HealthUsers_Email",
                table: "HealthUsers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HealthUsers_Email",
                table: "HealthUsers");
        }
    }
}
