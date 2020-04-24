using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialDiagnosisCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Sent = table.Column<bool>(nullable: false),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisKeys_DiagnosisId",
                table: "DiagnosisKeys",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_UserId",
                table: "Diagnosis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisKeys_Diagnosis_DiagnosisId",
                table: "DiagnosisKeys",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisKeys_Diagnosis_DiagnosisId",
                table: "DiagnosisKeys");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagnosisKeys",
                table: "DiagnosisKeys");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosisKeys_DiagnosisId",
                table: "DiagnosisKeys");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "DiagnosisKeys");

            migrationBuilder.RenameTable(
                name: "DiagnosisKeys",
                newName: "DiagnosisKey");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "DiagnosisKey",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HealthID",
                table: "DiagnosisKey",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Sent",
                table: "DiagnosisKey",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagnosisKey",
                table: "DiagnosisKey",
                column: "Id");
        }
    }
}
