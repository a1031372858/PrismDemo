using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlData.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                table: "role",
                column: "role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_game",
                table: "game",
                column: "game_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                table: "role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_game",
                table: "game");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "game",
                newName: "Game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "game_id");
        }
    }
}
