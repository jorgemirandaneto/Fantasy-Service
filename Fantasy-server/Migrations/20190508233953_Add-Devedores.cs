using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fantasy_server.Migrations
{
    public partial class AddDevedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devedores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fk_participante_ganhardor = table.Column<int>(nullable: false),
                    fk_participante_perdedor = table.Column<int>(nullable: false),
                    pago = table.Column<string>(maxLength: 1, nullable: true, defaultValue: "F")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devedores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Devedores_participante_fk_participante_ganhardor",
                        column: x => x.fk_participante_ganhardor,
                        principalSchema: "develop",
                        principalTable: "participante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devedores_participante_fk_participante_perdedor",
                        column: x => x.fk_participante_perdedor,
                        principalSchema: "develop",
                        principalTable: "participante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devedores_fk_participante_ganhardor",
                table: "Devedores",
                column: "fk_participante_ganhardor");

            migrationBuilder.CreateIndex(
                name: "IX_Devedores_fk_participante_perdedor",
                table: "Devedores",
                column: "fk_participante_perdedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devedores");
        }
    }
}
