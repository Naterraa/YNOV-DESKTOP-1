# Configurer la persistence avec EF Core

- Installer les packages Microsoft.EntityFrameworkCore.Sqlite et Microsoft.EntityFrameworkCore.Tools
- Créer une classe NotesDbContext héritant de DbContext.
- Ajouter la collection Notes: public DbSet<Note> Notes { get; set; } = null!;
- Configurer la connexion pour pointer vers "notes.db" dans le dossier de l'application
- Ajouter une propriété Id à la classe note
- Si tout est fait correctement, essayer d'exécuter la premiere migration Add-Migration InitialCreate et Update-Database
- Dans MainViewModel, utiliser le contexte pour charger les notes au démarrage de l'application (plus de données en dur)
- Modifier la commande d'ajout pour que la nouvelle note soit enregistrée en base de données (SaveChanges)
- Faire en sorte de gérer l'appréciation globale de maniere persistante en ajoutant une cLasse Appreciation avec id et texte et en modifiant les migrations pour qu'elle soit enregistrée en base de données (SaveChanges)