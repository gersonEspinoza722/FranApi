using Microsoft.EntityFrameworkCore.Migrations;

namespace FranChallenge.Migrations
{
    public partial class appointmentsFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentOffices_Appointments_AppointmentId",
                table: "AppointmentOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentOffices_Offices_OfficeId",
                table: "AppointmentOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPatients_Appointments_AppointmentId",
                table: "AppointmentPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPatients_Patients_PatientId",
                table: "AppointmentPatients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentPatients",
                table: "AppointmentPatients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentOffices",
                table: "AppointmentOffices");

            migrationBuilder.RenameTable(
                name: "AppointmentPatients",
                newName: "AppointmentPatient");

            migrationBuilder.RenameTable(
                name: "AppointmentOffices",
                newName: "AppointmentOffice");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentPatients_PatientId",
                table: "AppointmentPatient",
                newName: "IX_AppointmentPatient_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentOffices_OfficeId",
                table: "AppointmentOffice",
                newName: "IX_AppointmentOffice_OfficeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentPatient",
                table: "AppointmentPatient",
                columns: new[] { "AppointmentId", "PatientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentOffice",
                table: "AppointmentOffice",
                columns: new[] { "AppointmentId", "OfficeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentOffice_Appointments_AppointmentId",
                table: "AppointmentOffice",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentOffice_Offices_OfficeId",
                table: "AppointmentOffice",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPatient_Appointments_AppointmentId",
                table: "AppointmentPatient",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPatient_Patients_PatientId",
                table: "AppointmentPatient",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentOffice_Appointments_AppointmentId",
                table: "AppointmentOffice");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentOffice_Offices_OfficeId",
                table: "AppointmentOffice");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPatient_Appointments_AppointmentId",
                table: "AppointmentPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPatient_Patients_PatientId",
                table: "AppointmentPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentPatient",
                table: "AppointmentPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentOffice",
                table: "AppointmentOffice");

            migrationBuilder.RenameTable(
                name: "AppointmentPatient",
                newName: "AppointmentPatients");

            migrationBuilder.RenameTable(
                name: "AppointmentOffice",
                newName: "AppointmentOffices");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentPatient_PatientId",
                table: "AppointmentPatients",
                newName: "IX_AppointmentPatients_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentOffice_OfficeId",
                table: "AppointmentOffices",
                newName: "IX_AppointmentOffices_OfficeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentPatients",
                table: "AppointmentPatients",
                columns: new[] { "AppointmentId", "PatientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentOffices",
                table: "AppointmentOffices",
                columns: new[] { "AppointmentId", "OfficeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentOffices_Appointments_AppointmentId",
                table: "AppointmentOffices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentOffices_Offices_OfficeId",
                table: "AppointmentOffices",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPatients_Appointments_AppointmentId",
                table: "AppointmentPatients",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPatients_Patients_PatientId",
                table: "AppointmentPatients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
