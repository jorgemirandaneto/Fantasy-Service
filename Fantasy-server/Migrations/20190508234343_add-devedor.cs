using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy_server.Migrations
{
    public partial class adddevedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devedores_participante_fk_participante_ganhardor",
                table: "Devedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Devedores_participante_fk_participante_perdedor",
                table: "Devedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devedores",
                table: "Devedores");

            migrationBuilder.RenameTable(
                name: "Devedores",
                newName: "devedores",
                newSchema: "develop");

            migrationBuilder.RenameIndex(
                name: "IX_Devedores_fk_participante_perdedor",
                schema: "develop",
                table: "devedores",
                newName: "IX_devedores_fk_participante_perdedor");

            migrationBuilder.RenameIndex(
                name: "IX_Devedores_fk_participante_ganhardor",
                schema: "develop",
                table: "devedores",
                newName: "IX_devedores_fk_participante_ganhardor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_devedores",
                schema: "develop",
                table: "devedores",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_devedores_participante_fk_participante_ganhardor",
                schema: "develop",
                table: "devedores",
                column: "fk_participante_ganhardor",
                principalSchema: "develop",
                principalTable: "participante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_devedores_participante_fk_participante_perdedor",
                schema: "develop",
                table: "devedores",
                column: "fk_participante_perdedor",
                principalSchema: "develop",
                principalTable: "participante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_devedores_participante_fk_participante_ganhardor",
                schema: "develop",
                table: "devedores");

            migrationBuilder.DropForeignKey(
                name: "FK_devedores_participante_fk_participante_perdedor",
                schema: "develop",
                table: "devedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_devedores",
                schema: "develop",
                table: "devedores");

            migrationBuilder.RenameTable(
                name: "devedores",
                schema: "develop",
                newName: "Devedores");

            migrationBuilder.RenameIndex(
                name: "IX_devedores_fk_participante_perdedor",
                table: "Devedores",
                newName: "IX_Devedores_fk_participante_perdedor");

            migrationBuilder.RenameIndex(
                name: "IX_devedores_fk_participante_ganhardor",
                table: "Devedores",
                newName: "IX_Devedores_fk_participante_ganhardor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devedores",
                table: "Devedores",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devedores_participante_fk_participante_ganhardor",
                table: "Devedores",
                column: "fk_participante_ganhardor",
                principalSchema: "develop",
                principalTable: "participante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devedores_participante_fk_participante_perdedor",
                table: "Devedores",
                column: "fk_participante_perdedor",
                principalSchema: "develop",
                principalTable: "participante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
