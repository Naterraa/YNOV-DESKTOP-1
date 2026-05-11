using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Partie6.Models;

namespace Partie6.Services
{
    // Ce service concentre toute la logique d'accès aux données.
    // Le ViewModel ne doit plus connaître le DbContext, il passe par ce Service.
    // Tout est asynchrone (async/await) pour ne pas bloquer l'interface graphique !
    public class TodoService
    {
        // Récupérer toutes les tâches sans figer la fenêtre
        public async Task<List<Tache>> GetTachesAsync()
        {
            using var context = new TodoDbContext();
            return await context.Taches.ToListAsync();
        }

        // Ajouter une tâche en base
        public async Task AddTacheAsync(Tache tache)
        {
            using var context = new TodoDbContext();
            context.Taches.Add(tache);
            await context.SaveChangesAsync();
        }

        // Récupérer l'objectif global
        public async Task<Objectif?> GetObjectifAsync()
        {
            using var context = new TodoDbContext();
            return await context.Objectifs.FirstOrDefaultAsync();
        }

        // Enregistrer l'objectif global
        public async Task SaveObjectifAsync(Objectif objectif)
        {
            using var context = new TodoDbContext();
            
            // On vérifie si un objectif existe déjà
            var existant = await context.Objectifs.FirstOrDefaultAsync();
            if (existant == null)
            {
                context.Objectifs.Add(objectif);
            }
            else
            {
                existant.Texte = objectif.Texte;
            }

            await context.SaveChangesAsync();
        }
    }
}
