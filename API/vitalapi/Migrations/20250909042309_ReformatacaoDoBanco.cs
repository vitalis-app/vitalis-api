using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vitalapi.Migrations
{
    /// <inheritdoc />
    public partial class ReformatacaoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Especialista");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "DiaSemana",
                table: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Assinaturas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assinaturas");

            migrationBuilder.RenameColumn(
                name: "PlanoId",
                table: "Usuarios",
                newName: "Configuracoes_DispositivosConectados");

            migrationBuilder.RenameColumn(
                name: "Especialidade",
                table: "Especialistas",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Especialistas",
                newName: "Senha");

            migrationBuilder.AlterColumn<int>(
                name: "Genero",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AssinaturaAtivaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Configuracoes_PreferenciaNotificacoes_AlertaDiarioAtivo",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuracoes_PreferenciaNotificacoes_Id",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Configuracoes_PreferenciaNotificacoes_LembreteSessaoAtivo",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Configuracoes_PreferenciaNotificacoes_NotificacaoVideoAtiva",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuracoes_PreferenciaNotificacoes_Preferencia",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanoTipo",
                table: "Planos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AvaliacaoMedia",
                table: "Especialistas",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Configuracoes_DispositivosConectados",
                table: "Especialistas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Configuracoes_PreferenciaNotificacoes_AlertaDiarioAtivo",
                table: "Especialistas",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuracoes_PreferenciaNotificacoes_Id",
                table: "Especialistas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Configuracoes_PreferenciaNotificacoes_LembreteSessaoAtivo",
                table: "Especialistas",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Configuracoes_PreferenciaNotificacoes_NotificacaoVideoAtiva",
                table: "Especialistas",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuracoes_PreferenciaNotificacoes_Preferencia",
                table: "Especialistas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Especialistas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Especialistas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Especialidades",
                table: "Especialistas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Especialistas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Especialistas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioInicio",
                table: "Disponibilidades",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioFim",
                table: "Disponibilidades",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DiaDaSemana",
                table: "Disponibilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EspecialistaId",
                table: "Disponibilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Vencimento",
                table: "Assinaturas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Assinaturas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "Assinaturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Assinaturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EspecialistaId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusAtual = table.Column<int>(type: "int", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Especialistas_EspecialistaId",
                        column: x => x.EspecialistaId,
                        principalTable: "Especialistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeXP = table.Column<int>(type: "int", nullable: false),
                    ObjetivoTipo = table.Column<int>(type: "int", nullable: false),
                    QuantidadeObjetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Missoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeXP = table.Column<int>(type: "int", nullable: false),
                    ObjetivoTipo = table.Column<int>(type: "int", nullable: false),
                    QuantidadeObjetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Foto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistrosEmocionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DiaRegistrado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HumorRegistrado = table.Column<int>(type: "int", nullable: false),
                    ConfissaoUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosEmocionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosEmocionais_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioProgressos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    XPTotal = table.Column<int>(type: "int", nullable: false),
                    DiasAtivosStreak = table.Column<int>(type: "int", nullable: false),
                    UltimaAtividade = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    QuantidadeCheckins = table.Column<int>(type: "int", nullable: false),
                    TempoMedioUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProgressos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioProgressos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioSessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ComecoSessao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FimSessao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSessoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DuracaoSegundos = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Visualizacoes = table.Column<int>(type: "int", nullable: false),
                    Curtidas = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Premium = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioMissoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    MissaoId = table.Column<int>(type: "int", nullable: false),
                    ProgressoConquista = table.Column<int>(type: "int", nullable: false),
                    isConluida = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioMissoes_Missoes_MissaoId",
                        column: x => x.MissaoId,
                        principalTable: "Missoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioMissoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioPlantas",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PlantaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataPlantio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaRega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPlantas", x => new { x.UsuarioId, x.PlantaId });
                    table.ForeignKey(
                        name: "FK_UsuarioPlantas_Plantas_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Plantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPlantas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioConquistas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioProgressoId = table.Column<int>(type: "int", nullable: false),
                    ConquistaId = table.Column<int>(type: "int", nullable: false),
                    ProgressoConquista = table.Column<int>(type: "int", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusConquista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioConquistas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsuarioConquistas_Conquistas_ConquistaId",
                        column: x => x.ConquistaId,
                        principalTable: "Conquistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioConquistas_UsuarioProgressos_UsuarioProgressoId",
                        column: x => x.UsuarioProgressoId,
                        principalTable: "UsuarioProgressos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioHumores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Humor = table.Column<int>(type: "int", nullable: false),
                    UsuarioProgressoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioHumores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioHumores_UsuarioProgressos_UsuarioProgressoId",
                        column: x => x.UsuarioProgressoId,
                        principalTable: "UsuarioProgressos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AssinaturaAtivaId",
                table: "Usuarios",
                column: "AssinaturaAtivaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_EspecialistaId",
                table: "Disponibilidades",
                column: "EspecialistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Assinaturas_PlanoId",
                table: "Assinaturas",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EspecialistaId",
                table: "Agendamentos",
                column: "EspecialistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioId",
                table: "Agendamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEmocionais_UsuarioId",
                table: "RegistrosEmocionais",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioConquistas_ConquistaId",
                table: "UsuarioConquistas",
                column: "ConquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioConquistas_UsuarioProgressoId",
                table: "UsuarioConquistas",
                column: "UsuarioProgressoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioHumores_UsuarioProgressoId",
                table: "UsuarioHumores",
                column: "UsuarioProgressoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMissoes_MissaoId",
                table: "UsuarioMissoes",
                column: "MissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMissoes_UsuarioId",
                table: "UsuarioMissoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPlantas_PlantaId",
                table: "UsuarioPlantas",
                column: "PlantaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProgressos_UsuarioId",
                table: "UsuarioProgressos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSessoes_UsuarioId",
                table: "UsuarioSessoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UsuarioId",
                table: "Videos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinaturas_Planos_PlanoId",
                table: "Assinaturas",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disponibilidades_Especialistas_EspecialistaId",
                table: "Disponibilidades",
                column: "EspecialistaId",
                principalTable: "Especialistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Assinaturas_AssinaturaAtivaId",
                table: "Usuarios",
                column: "AssinaturaAtivaId",
                principalTable: "Assinaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinaturas_Planos_PlanoId",
                table: "Assinaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Disponibilidades_Especialistas_EspecialistaId",
                table: "Disponibilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Assinaturas_AssinaturaAtivaId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "RegistrosEmocionais");

            migrationBuilder.DropTable(
                name: "UsuarioConquistas");

            migrationBuilder.DropTable(
                name: "UsuarioHumores");

            migrationBuilder.DropTable(
                name: "UsuarioMissoes");

            migrationBuilder.DropTable(
                name: "UsuarioPlantas");

            migrationBuilder.DropTable(
                name: "UsuarioSessoes");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Conquistas");

            migrationBuilder.DropTable(
                name: "UsuarioProgressos");

            migrationBuilder.DropTable(
                name: "Missoes");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AssinaturaAtivaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Disponibilidades_EspecialistaId",
                table: "Disponibilidades");

            migrationBuilder.DropIndex(
                name: "IX_Assinaturas_PlanoId",
                table: "Assinaturas");

            migrationBuilder.DropColumn(
                name: "AssinaturaAtivaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_AlertaDiarioAtivo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_LembreteSessaoAtivo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_NotificacaoVideoAtiva",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_Preferencia",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PlanoTipo",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "AvaliacaoMedia",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Configuracoes_DispositivosConectados",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_AlertaDiarioAtivo",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_Id",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_LembreteSessaoAtivo",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_NotificacaoVideoAtiva",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Configuracoes_PreferenciaNotificacoes_Preferencia",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Especialidades",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Especialistas");

            migrationBuilder.DropColumn(
                name: "DiaDaSemana",
                table: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "EspecialistaId",
                table: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Assinaturas");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Assinaturas");

            migrationBuilder.RenameColumn(
                name: "Configuracoes_DispositivosConectados",
                table: "Usuarios",
                newName: "PlanoId");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Especialistas",
                newName: "Especialidade");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Especialistas",
                newName: "Descricao");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Planos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HorarioInicio",
                table: "Disponibilidades",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HorarioFim",
                table: "Disponibilidades",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DiaSemana",
                table: "Disponibilidades",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Vencimento",
                table: "Assinaturas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DataInicio",
                table: "Assinaturas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Assinaturas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Assinaturas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especialista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorPago = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialista", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
