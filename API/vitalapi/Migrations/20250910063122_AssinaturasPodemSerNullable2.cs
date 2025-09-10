using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vitalapi.Migrations
{
    /// <inheritdoc />
    public partial class AssinaturasPodemSerNullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Assinaturas_AssinaturaAtivaId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "AssinaturaAtivaId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Assinaturas_AssinaturaAtivaId",
                table: "Usuarios",
                column: "AssinaturaAtivaId",
                principalTable: "Assinaturas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Assinaturas_AssinaturaAtivaId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "AssinaturaAtivaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Assinaturas_AssinaturaAtivaId",
                table: "Usuarios",
                column: "AssinaturaAtivaId",
                principalTable: "Assinaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
