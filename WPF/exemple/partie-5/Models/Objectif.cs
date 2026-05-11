using System.ComponentModel.DataAnnotations;

namespace Partie5.Models
{
    // Modèle de données pour stocker l'objectif global de la semaine
    public class Objectif
    {
        [Key]
        public int Id { get; set; }
        
        public string Texte { get; set; } = string.Empty;
    }
}
