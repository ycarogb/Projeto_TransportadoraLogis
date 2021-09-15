using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportadoraLogis.Migrations
{
    public partial class @private : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "targetId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "targetUserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_targetUserId",
                table: "Messages",
                column: "targetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_targetUserId",
                table: "Messages",
                column: "targetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_targetUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_targetUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "targetId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "targetUserId",
                table: "Messages");
        }
    }
}
