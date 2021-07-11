﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SqlData;

namespace SqlData.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20210711105920_IdUpdate")]
    partial class IdUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SqlData.Beans.Game", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("game_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUser")
                        .HasColumnName("create_user")
                        .HasColumnType("integer");

                    b.Property<string>("GameDesc")
                        .HasColumnName("game_desc")
                        .HasColumnType("text");

                    b.Property<string>("GameName")
                        .HasColumnName("game_name")
                        .HasColumnType("text");

                    b.Property<int>("PlayTotal")
                        .HasColumnName("play_total")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdateUser")
                        .HasColumnName("update_user")
                        .HasColumnType("integer");

                    b.HasKey("GameId");

                    b.ToTable("game");
                });

            modelBuilder.Entity("SqlData.Beans.Rank", b =>
                {
                    b.Property<long>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rank_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUser")
                        .HasColumnName("create_user")
                        .HasColumnType("integer");

                    b.Property<long>("GameId")
                        .HasColumnName("game_id")
                        .HasColumnType("bigint");

                    b.Property<int>("Grade")
                        .HasColumnName("grade")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdateUser")
                        .HasColumnName("update_user")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("RankId");

                    b.ToTable("rank");
                });

            modelBuilder.Entity("SqlData.Beans.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("role_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUser")
                        .HasColumnName("create_user")
                        .HasColumnType("integer");

                    b.Property<int>("RoleName")
                        .HasColumnName("role_name")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdateUser")
                        .HasColumnName("update_user")
                        .HasColumnType("integer");

                    b.HasKey("RoleId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("SqlData.Beans.UserDetail", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnName("birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUser")
                        .HasColumnName("create_user")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnName("sex")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdateUser")
                        .HasColumnName("update_user")
                        .HasColumnType("integer");

                    b.Property<string>("UserPassword")
                        .HasColumnName("user_password")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("user_detail");
                });
#pragma warning restore 612, 618
        }
    }
}