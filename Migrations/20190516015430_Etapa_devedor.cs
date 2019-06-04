using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy_server.Migrations
{
    public partial class Etapa_devedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_etapa_devedores",
                schema: "develop",
                table: "devedores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fk_etapa_devedores",
                schema: "develop",
                table: "devedores");
        }
    }
}
