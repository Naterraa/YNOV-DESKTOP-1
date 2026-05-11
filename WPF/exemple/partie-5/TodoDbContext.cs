using Microsoft.EntityFrameworkCore;
using Partie5.Models;

namespace Partie5
{
    // Le DbContext est le pont entre notre application WPF et la base de données SQLite.
    // Il gère les connexions et convertit nos requêtes C# en requêtes SQL automatiquement.
    public class TodoDbContext : DbContext
    {
        // Tables de la base de données
        public DbSet<Tache> Taches { get; set; } = null!;
        public DbSet<Objectif> Objectifs { get; set; } = null!;

        // Méthode appelée pour configurer la base de données
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // On utilise SQLite. Le fichier 'todo.db' sera créé à la racine du dossier d'exécution (bin/Debug/...)
            optionsBuilder.UseSqlite("Data Source=todo.db");
        }
    }
}
