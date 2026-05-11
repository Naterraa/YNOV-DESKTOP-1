using System;

namespace Partie3
{
    // Classe représentant une tâche à accomplir
    public class Tache
    {
        public string Titre { get; set; } = string.Empty;
        public string Priorite { get; set; } = string.Empty;
        public string Categorie { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; }

        // Redéfinition de ToString pour l'affichage simple dans la ListBox
        public override string ToString()
        {
            return $"{Titre} - {Priorite} - {Categorie} - {DateCreation.ToShortDateString()}";
        }
    }
}
