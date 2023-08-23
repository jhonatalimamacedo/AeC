using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeCAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aeroporto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    umidade = table.Column<int>(type: "int", nullable: false),
                    visibilidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_icao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pressao_atmosferica = table.Column<int>(type: "int", nullable: false),
                    vento = table.Column<int>(type: "int", nullable: false),
                    direcao_vento = table.Column<int>(type: "int", nullable: false),
                    condicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condicao_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    temp = table.Column<int>(type: "int", nullable: false),
                    atualizado_em = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aeroporto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    atualizado_em = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    codeMessage = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "climas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condicao_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    min = table.Column<int>(type: "int", nullable: false),
                    max = table.Column<int>(type: "int", nullable: false),
                    indice_uv = table.Column<int>(type: "int", nullable: false),
                    idCidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_climas", x => x.id);
                    table.ForeignKey(
                        name: "FK_climas_cidades_idCidade",
                        column: x => x.idCidade,
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_climas_idCidade",
                table: "climas",
                column: "idCidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aeroporto");

            migrationBuilder.DropTable(
                name: "climas");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "cidades");
        }
    }
}
