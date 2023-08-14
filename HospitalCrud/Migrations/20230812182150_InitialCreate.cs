using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCrud.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    FotoBase64 = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
