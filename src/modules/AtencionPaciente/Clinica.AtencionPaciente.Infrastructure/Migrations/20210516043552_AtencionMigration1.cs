using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.AtencionPaciente.Infrastructure.Migrations
{
    public partial class AtencionMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialistas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitales",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasClinicas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CantidadPacientes = table.Column<int>(nullable: false),
                    TipoConsulta = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    EspecialistaId = table.Column<string>(nullable: true),
                    HospitalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasClinicas_Especialistas_EspecialistaId",
                        column: x => x.EspecialistaId,
                        principalTable: "Especialistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultasClinicas_Hospitales_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    NumeroHistoriasClinico = table.Column<string>(nullable: true),
                    HospitalId = table.Column<string>(nullable: true),
                    Prioridad = table.Column<double>(nullable: false),
                    Riesgo = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    TieneDieta = table.Column<bool>(nullable: true),
                    EsFumador = table.Column<bool>(nullable: true),
                    AnnosFumando = table.Column<int>(nullable: true),
                    RelacionPesoEstatura = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Hospitales_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasClinicas_EspecialistaId",
                table: "ConsultasClinicas",
                column: "EspecialistaId",
                unique: true,
                filter: "[EspecialistaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasClinicas_HospitalId",
                table: "ConsultasClinicas",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_HospitalId",
                table: "Paciente",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasClinicas");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Especialistas");

            migrationBuilder.DropTable(
                name: "Hospitales");
        }
    }
}
