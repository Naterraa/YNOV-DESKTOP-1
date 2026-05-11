using System.ComponentModel.DataAnnotations;

namespace Partie6.Models
{
    public class Objectif
    {
        [Key]
        public int Id { get; set; }
        
        public string Texte { get; set; } = string.Empty;
    }
}
