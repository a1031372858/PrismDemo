using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SqlData.Beans;

namespace SqlData
{
    public class PostgreSqlContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"PORT=5432;DATABASE=usermanager;HOST=localhost;PASSWORD=666666;USER ID=postgres;");
        }

        
        public DbSet<UserDetail> UserDetail { set; get; }
    }
}