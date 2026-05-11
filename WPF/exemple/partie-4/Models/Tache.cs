using System;

namespace Partie4.Models
{
    // Le modèle de données représente l'information brute.
    // Il ne connaît ni la vue (UI), ni le ViewModel.
    public class Tache
    {
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
