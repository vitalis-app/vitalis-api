using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vitalapi.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirRelacaoEspecialistaEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidades",
                table: "Especialistas");

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialistaId = table.Column<int>(type: "int", nullable: false),
                    Especialidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => new { x.EspecialistaId, x.Especialidade });
                    table.ForeignKey(
                        name: "FK_Especialidades_Especialistas_EspecialistaId",
                        column: x => x.EspecialistaId,
                        principalTable: "Especialistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.AddColumn<string>(
                name: "Especialidades",
                table: "Especialistas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
