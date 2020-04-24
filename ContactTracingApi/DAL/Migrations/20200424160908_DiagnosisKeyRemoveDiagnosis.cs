using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DiagnosisKeyRemoveDiagnosis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisKeys_Diagnosis_DiagnosisId",
                table: "DiagnosisKeys");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "DiagnosisKeys",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisKeys_Diagnosis_DiagnosisId",
                table: "DiagnosisKeys",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisKeys_Diagnosis_DiagnosisId",
                table: "DiagnosisKeys");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "DiagnosisKeys",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisKeys_Diagnosis_DiagnosisId",
                table: "DiagnosisKeys",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
