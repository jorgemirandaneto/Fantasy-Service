using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fantasy_server.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "develop");

            migrationBuilder.CreateTable(
                name: "acessuser",
                schema: "develop",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    fkparticipante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acessuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etapa",
                schema: "develop",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etapa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "participante",
                schema: "develop",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etapaparticipante",
                schema: "develop",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fk_participante = table.Column<int>(nullable: false),
                    fk_etapa = table.Column<int>(nullable: false),
                    nota = table.Column<double>(nullable: false),
                    ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etapaparticipante", x => x.id);
                    table.ForeignKey(
                        name: "FK_etapaparticipante_etapa_fk_etapa",
                        column: x => x.fk_etapa,
                        principalSchema: "develop",
                        principalTable: "etapa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etapaparticipante_participante_fk_participante",
                        column: x => x.fk_participante,
                        principalSchema: "develop",
                        principalTable: "participante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_etapaparticipante_fk_etapa",
                schema: "develop",
                table: "etapaparticipante",
                column: "fk_etapa");

            migrationBuilder.CreateIndex(
                name: "IX_etapaparticipante_fk_participante",
                schema: "develop",
                table: "etapaparticipante",
                column: "fk_participante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acessuser",
                schema: "develop");

            migrationBuilder.DropTable(
                name: "etapaparticipante",
                schema: "develop");

            migrationBuilder.DropTable(
                name: "etapa",
                schema: "develop");

            migrationBuilder.DropTable(
                name: "participante",
                schema: "develop");
        }
    }
}
