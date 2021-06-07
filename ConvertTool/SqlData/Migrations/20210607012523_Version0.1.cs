﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SqlData.Migrations
{
    public partial class Version01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    game_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    update_user = table.Column<int>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    create_user = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    game_name = table.Column<string>(nullable: true),
                    game_desc = table.Column<string>(nullable: true),
                    play_total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.game_id);
                });

            migrationBuilder.CreateTable(
                name: "rank",
                columns: table => new
                {
                    rank_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    update_user = table.Column<int>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    create_user = table.Column<int>(nullable: false),
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
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    update_user = table.Column<int>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    create_user = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    role_name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "user_detail",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    update_user = table.Column<int>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    create_user = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    user_password = table.Column<string>(nullable: true),
                    display_name = table.Column<string>(nullable: true),
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
                name: "game");

            migrationBuilder.DropTable(
                name: "rank");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user_detail");
        }
    }
}
