using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Partie4.Models;

namespace Partie4.ViewModels
{
    // Le ViewModel fait le lien entre la Vue (UI) et le Modèle (Données).
    // INotifyPropertyChanged permet de prévenir l'interface graphique quand une donnée change.
    public class MainViewModel : INotifyPropertyChanged
    {
        // On utilise ObservableCollection au lieu de List car elle notifie 
        // automatiquement l'interface WPF (la ListBox) quand on ajoute ou supprime un élément.
        public ObservableCollection<Tache> Taches { get; set; }

        // Propriétés liées aux champs de saisie de la vue
        private string _nouvelleTacheTitre = string.Empty;
        public string NouvelleTacheTitre
        {
            get => _nouvelleTacheTitre;
            set
            {
                _nouvelleTacheTitre = value;
                OnPropertyChanged();
            }
        }

        private string _nouvelleTacheCategorie = string.Empty;
        public string NouvelleTacheCategorie
        {
            get => _nouvelleTacheCategorie;
            set
            {
                _nouvelleTacheCategorie = value;
                OnPropertyChanged();
            }
        }

        private string _nouvelleTachePriorite = "Normale";
        public string NouvelleTachePriorite
        {
            get => _nouvelleTachePriorite;
            set
            {
                _nouvelleTachePriorite = value;
                OnPropertyChanged();
            }
        }

        private string _objectifSemaine = "Avancer au maximum sur mes projets personnels.";
        public string ObjectifSemaine
        {
            get => _objectifSemaine;
            set
            {
                _objectifSemaine = value;
                OnPropertyChanged();
            }
        }

        // Déclaration des commandes (actions)
        public ICommand AjouterTacheCommand { get; }
        public ICommand EnregistrerObjectifCommand { get; }

        public MainViewModel()
        {
            // Initialisation des données de test
            Taches = new ObservableCollection<Tache>
            {
                new Tache { Titre = "Faire les courses", Priorite = "Haute", Categorie = "Personnel", DateCreation = DateTime.Now },
                new Tache { Titre = "Terminer le TP WPF", Priorite = "Normale", Categorie = "Études", DateCreation = DateTime.Now }
            };

            // Initialisation des commandes en associant les méthodes correspondantes
            AjouterTacheCommand = new RelayCommand(AjouterTache, PeutAjouterTache);
            EnregistrerObjectifCommand = new RelayCommand(EnregistrerObjectif);
        }

        // Méthode exécutée par AjouterTacheCommand
        private void AjouterTache(object? parameter)
        {
            var tache = new Tache
            {
                Titre = NouvelleTacheTitre,
                Categorie = NouvelleTacheCategorie,
                Priorite = NouvelleTachePriorite,
                DateCreation = DateTime.Now
            };

            Taches.Add(tache); // L'interface se mettra à jour toute seule !

            // On réinitialise les champs de saisie
            NouvelleTacheTitre = string.Empty;
            NouvelleTacheCategorie = string.Empty;
            NouvelleTachePriorite = "Normale";
        }

        // Condition pour que le bouton Ajouter soit cliquable (activé)
        private bool PeutAjouterTache(object? parameter)
        {
            // Le bouton sera grisé si le titre est vide
            return !string.IsNullOrWhiteSpace(NouvelleTacheTitre);
        }

        // Méthode exécutée par EnregistrerObjectifCommand
        private void EnregistrerObjectif(object? parameter)
        {
            MessageBox.Show("Objectif sauvegardé en mémoire (temporairement) :\n" + ObjectifSemaine, "Succès MVVM");
        }


        // --- Implémentation de INotifyPropertyChanged ---
        public event PropertyChangedEventHandler? PropertyChanged;

        // Cette méthode notifie la vue qu'une propriété a changé de valeur.
        // [CallerMemberName] permet de récupérer automatiquement le nom de la propriété appelante.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
