using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "VWRELATORIOLIVROS",
                columns: table => new
                {
                    Livro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Codl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssuntoCodAs = table.Column<int>(type: "int", nullable: true),
                    AutorCodAu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Codl);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_AssuntoCodAs",
                        column: x => x.AssuntoCodAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs");
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AutorCodAu",
                        column: x => x.AutorCodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu");
                });

            migrationBuilder.CreateTable(
                name: "Livro_Assunto",
                columns: table => new
                {
                    Livro_Codl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assunto_CodAs = table.Column<int>(type: "int", nullable: false),
                    LivroCodl = table.Column<int>(type: "int", nullable: false),
                    AssuntoCodAs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Assunto", x => x.Livro_Codl);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Assunto_AssuntoCodAs",
                        column: x => x.AssuntoCodAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Livro_LivroCodl",
                        column: x => x.LivroCodl,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Autor",
                columns: table => new
                {
                    Livro_Codl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor_CodAu = table.Column<int>(type: "int", nullable: false),
                    LivroCodl = table.Column<int>(type: "int", nullable: false),
                    AutorCodAu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Autor", x => x.Livro_Codl);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Autor_AutorCodAu",
                        column: x => x.AutorCodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Livro_LivroCodl",
                        column: x => x.LivroCodl,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AssuntoCodAs",
                table: "Livro",
                column: "AssuntoCodAs");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorCodAu",
                table: "Livro",
                column: "AutorCodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Assunto_AssuntoCodAs",
                table: "Livro_Assunto",
                column: "AssuntoCodAs");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Assunto_LivroCodl",
                table: "Livro_Assunto",
                column: "LivroCodl");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autor_AutorCodAu",
                table: "Livro_Autor",
                column: "AutorCodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autor_LivroCodl",
                table: "Livro_Autor",
                column: "LivroCodl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Assunto");

            migrationBuilder.DropTable(
                name: "Livro_Autor");

            migrationBuilder.DropTable(
                name: "VWRELATORIOLIVROS");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
