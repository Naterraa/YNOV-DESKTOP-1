using System;
using System.ComponentModel.DataAnnotations;

namespace Partie5.Models
{
    // Modèle de données enrichi pour Entity Framework Core
    public class Tache
    {
        [Key] // Indique que c'est la clé primaire dans la base de données SQLite
        public int Id { get; set; }
        
        public string Titre { get; set; } = string.Empty;
        public string Priorite { get; set; } = string.Empty;
        public string Categorie { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; }

        public override string ToString()
        {
            return $"{Titre} - {Priorite} - {Categorie} - {DateCreation.ToShortDateString()}";
        }
    }
}
