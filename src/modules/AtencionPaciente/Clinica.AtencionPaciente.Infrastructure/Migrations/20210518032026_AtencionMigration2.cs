using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.AtencionPaciente.Infrastructure.Migrations
{
    public partial class AtencionMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sala",
                table: "Hospitales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sala",
                table: "Hospitales");
        }
    }
}
