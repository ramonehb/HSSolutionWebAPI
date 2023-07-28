using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSSolution.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Perfil = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NR_CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NR_Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FL_Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    NR_UltimoAcesso = table.Column<int>(type: "int", nullable: false),
                    DT_UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_Expiracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NR_Tentativa = table.Column<int>(type: "int", nullable: false),
                    DT_UltimaTentativa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
