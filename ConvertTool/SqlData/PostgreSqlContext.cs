﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SqlData.Beans;

namespace SqlData
{
    //生成数据库需要添加包EntityFrameworkCore.Tools
    //然后在管理包控制台输入代码Add-Migration Init_First生成执行代码
    //生成后在输入代码Update-Database来生成数据库
    public class PostgreSqlContext:DbContext
    {
        private const string Port = "5432";
        private const string DbName = "usermanager";
        private const string Host = "192.168.1.88";
        private const string UserId = "postgres";
        private const string Password = "root";

        // private readonly ILoggerFactory _factory;
        //
        // public PostgreSqlContext(ILoggerFactory loggerFactory)
        // {
        //     _factory = loggerFactory;
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($@"PORT={Port};DATABASE={DbName};HOST={Host};PASSWORD={Password};USER ID={UserId};");
        }

        public DbSet<UserDetail> UserDetail { set; get; }

        public DbSet<Rank> Rank { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}