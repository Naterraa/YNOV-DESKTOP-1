using Microsoft.EntityFrameworkCore;
using Application_wpf.Models;

namespace Application_wpf.Models;

public class NotesDbContext : DbContext {
    public DbSet<Note> Notes { get; set; } = null!;
    public DbSet<Appreciation> Appreciations { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=notes.db");
    }
}
