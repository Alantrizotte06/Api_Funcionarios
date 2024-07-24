using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionarioApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Departamento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salario = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Cpf);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Desenvolvedor",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinguagemDeProgramacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedor", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Desenvolvedor_Funcionario_Cpf",
                        column: x => x.Cpf,
                        principalTable: "Funcionario",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estagiario",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HorasPorSemana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estagiario", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Estagiario_Funcionario_Cpf",
                        column: x => x.Cpf,
                        principalTable: "Funcionario",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bonificacao = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Gerente_Funcionario_Cpf",
                        column: x => x.Cpf,
                        principalTable: "Funcionario",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desenvolvedor");

            migrationBuilder.DropTable(
                name: "Estagiario");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
