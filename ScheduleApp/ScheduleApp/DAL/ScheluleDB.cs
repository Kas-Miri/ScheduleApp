using Microsoft.EntityFrameworkCore;
using ScheduleApp.Models;

namespace ScheduleApp.DAL
{
    public class ScheluleDB : DbContext
    {
        public DbSet<Time> Time { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Kas Miri\Documents\1A УЧЁБА\6\C#\ScheduleApp\test.db");
        }
    }
}
