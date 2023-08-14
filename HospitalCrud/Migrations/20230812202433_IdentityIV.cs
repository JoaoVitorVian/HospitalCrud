using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCrud.Migrations
{
    /// <inheritdoc />
    public partial class IdentityIV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Paciente",
                schema: "Identity",
                table: "Paciente");

            migrationBuilder.RenameTable(
                name: "Paciente",
                schema: "Identity",
                newName: "Pacientes",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                schema: "Identity",
                table: "Pacientes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                schema: "Identity",
                table: "Pacientes");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                schema: "Identity",
                newName: "Paciente",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paciente",
                schema: "Identity",
                table: "Paciente",
                column: "Id");
        }
    }
}
