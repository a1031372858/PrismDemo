using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SqlData.Migrations
{
    public partial class Init_First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rank",
                columns: table => new
                {
                    rank_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    update_user = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: false),
                    create_user = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    game_id = table.Column<int>(nullable: false),
                    grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rank", x => x.rank_id);
                });

            migrationBuilder.CreateTable(
                name: "user_detail",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    update_user = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: false),
                    create_user = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    user_password = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true),
                    birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_detail", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rank");

            migrationBuilder.DropTable(
                name: "user_detail");
        }
    }
}
