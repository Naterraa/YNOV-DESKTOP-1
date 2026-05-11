using System;
using System.ComponentModel.DataAnnotations;

namespace Partie6.Models
{
    public class Tache
    {
        [Key]
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
