using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSSolution.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newDbHSSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    ID_Fatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_SubEstipulante = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DT_Cadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fatura__9F2CBCBD4E544CC8", x => x.ID_Fatura);
                });

            migrationBuilder.CreateTable(
                name: "Perfils",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmDescricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Cobranca",
                columns: table => new
                {
                    ID_Cobranca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Fatura = table.Column<int>(type: "int", nullable: false),
                    NR_Parcela = table.Column<int>(type: "int", nullable: true),
                    VL_Bruto = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    VL_Liquido = table.Column<decimal>(type: "numeric(16,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cobranca__AA56A536FF00E511", x => x.ID_Cobranca);
                    table.ForeignKey(
                        name: "FK_Cobranca_Fatura",
                        column: x => x.ID_Fatura,
                        principalTable: "Fatura",
                        principalColumn: "ID_Fatura");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlHabilitado = table.Column<bool>(type: "bit", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NrUltimoAcesso = table.Column<int>(type: "int", nullable: true),
                    DtUltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtExpiracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NrTentativa = table.Column<int>(type: "int", nullable: true),
                    DtUltimaTentativa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPerfilNavigationIdPerfil = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfils_IdPerfilNavigationIdPerfil",
                        column: x => x.IdPerfilNavigationIdPerfil,
                        principalTable: "Perfils",
                        principalColumn: "IdPerfil");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_001",
                table: "Cobranca",
                column: "ID_Fatura");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfilNavigationIdPerfil",
                table: "Usuarios",
                column: "IdPerfilNavigationIdPerfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobranca");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Perfils");
        }
    }
}
