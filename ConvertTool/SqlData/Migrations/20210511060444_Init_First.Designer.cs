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
    [Migration("20210511060444_Init_First")]
    partial class Init_First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SqlData.Beans.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rank_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUser")
                        .HasColumnName("create_user")
                        .HasColumnType("text");

                    b.Property<int>("GameId")
                        .HasColumnName("game_id")
                        .HasColumnType("integer");

                    b.Property<int>("Grade")
                        .HasColumnName("grade")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdateUser")
                        .HasColumnName("update_user")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("RankId");

                    b.ToTable("rank");
                });

            modelBuilder.Entity("SqlData.Beans.UserDetail", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnName("birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUser")
                        .HasColumnName("create_user")
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

                    b.Property<string>("UpdateUser")
                        .HasColumnName("update_user")
                        .HasColumnType("text");

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
