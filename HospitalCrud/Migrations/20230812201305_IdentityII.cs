using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCrud.Migrations
{
    /// <inheritdoc />
    public partial class IdentityII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "Paciente",
                newName: "Paciente",
                newSchema: "Identity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Paciente",
                schema: "Identity",
                newName: "Paciente");
        }
    }
}
