using Microsoft.EntityFrameworkCore.Migrations;

namespace FranChallenge.Migrations
{
    public partial class appointmentsFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Offices_officeid",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_patientid",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "patientid",
                table: "Appointments",
                newName: "patientId");

            migrationBuilder.RenameColumn(
                name: "officeid",
                table: "Appointments",
                newName: "officeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_patientid",
                table: "Appointments",
                newName: "IX_Appointments_patientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_officeid",
                table: "Appointments",
                newName: "IX_Appointments_officeId");

            migrationBuilder.AlterColumn<int>(
                name: "patientId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "officeId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Offices_officeId",
                table: "Appointments",
                column: "officeId",
                principalTable: "Offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_patientId",
                table: "Appointments",
                column: "patientId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Offices_officeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_patientId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "Appointments",
                newName: "patientid");

            migrationBuilder.RenameColumn(
                name: "officeId",
                table: "Appointments",
                newName: "officeid");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_patientId",
                table: "Appointments",
                newName: "IX_Appointments_patientid");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_officeId",
                table: "Appointments",
                newName: "IX_Appointments_officeid");

            migrationBuilder.AlterColumn<int>(
                name: "patientid",
                table: "Appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "officeid",
                table: "Appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Offices_officeid",
                table: "Appointments",
                column: "officeid",
                principalTable: "Offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_patientid",
                table: "Appointments",
                column: "patientid",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
