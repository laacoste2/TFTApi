using Microsoft.EntityFrameworkCore;
using TeamFightTacticsAPI.Models;

namespace TeamFightTacticsAPI.Data
{
    public class TeamFightTacticsContext : DbContext
    {
        public DbSet<Champion> Champions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydb.sqlite");
            base.OnConfiguring(optionsBuilder);

            
        }
    }
}
