using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportadoraLogis.Migrations
{
    public partial class novos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
