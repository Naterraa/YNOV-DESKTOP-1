using Microsoft.EntityFrameworkCore;
using Partie6.Models;

namespace Partie6
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Tache> Taches { get; set; } = null!;
        public DbSet<Objectif> Objectifs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo.db");
        }
    }
}
