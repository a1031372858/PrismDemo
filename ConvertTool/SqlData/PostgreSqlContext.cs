using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SqlData.Beans;

namespace SqlData
{
    public class PostgreSqlContext:DbContext
    {
        private const string Port = "5432";
        private const string DbName = "usermanager";
        private const string Host = "localhost";
        private const string UserId = "postgres";
        private const string Password = "666666";

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
    }
}