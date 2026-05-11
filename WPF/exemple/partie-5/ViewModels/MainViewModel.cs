using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Partie5.Models;

namespace Partie5.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Contexte de base de données EF Core
        private readonly TodoDbContext _dbContext;

        public ObservableCollection<Tache> Taches { get; set; }

        private string _nouvelleTacheTitre = string.Empty;
        public string NouvelleTacheTitre
        {
            get => _nouvelleTacheTitre;
            set { _nouvelleTacheTitre = value; OnPropertyChanged(); }
        }

        private string _nouvelleTacheCategorie = string.Empty;
        public string NouvelleTacheCategorie
        {
            get => _nouvelleTacheCategorie;
            set { _nouvelleTacheCategorie = value; OnPropertyChanged(); }
        }

        private string _nouvelleTachePriorite = "Normale";
        public string NouvelleTachePriorite
        {
            get => _nouvelleTachePriorite;
            set { _nouvelleTachePriorite = value; OnPropertyChanged(); }
        }

        private string _objectifSemaine = string.Empty;
        public string ObjectifSemaine
        {
            get => _objectifSemaine;
            set { _objectifSemaine = value; OnPropertyChanged(); }
        }

        public ICommand AjouterTacheCommand { get; }
        public ICommand EnregistrerObjectifCommand { get; }

        public MainViewModel()
        {
            _dbContext = new TodoDbContext();

            // S'assure que la base de données existe (crée le fichier todo.db s'il n'existe pas)
            // Dans un vrai projet de production, on utiliserait plutôt les Migrations.
            // _dbContext.Database.EnsureCreated(); // Optionnel : à activer si on ne fait pas les migrations en cours

            // On charge les données depuis la base de données
            Taches = new ObservableCollection<Tache>(_dbContext.Taches.ToList());

            // On charge l'objectif s'il existe
            var objectif = _dbContext.Objectifs.FirstOrDefault();
            if (objectif != null)
            {
                ObjectifSemaine = objectif.Texte;
            }

            AjouterTacheCommand = new RelayCommand(AjouterTache, PeutAjouterTache);
            EnregistrerObjectifCommand = new RelayCommand(EnregistrerObjectif);
        }

        private void AjouterTache(object? parameter)
        {
            var tache = new Tache
            {
                Titre = NouvelleTacheTitre,
                Categorie = NouvelleTacheCategorie,
                Priorite = NouvelleTachePriorite,
                DateCreation = DateTime.Now
            };

            // Ajout dans la base de données via EF Core
            _dbContext.Taches.Add(tache);
            _dbContext.SaveChanges(); // Persistance sur le disque !

            // Ajout dans l'interface (mémoire)
            Taches.Add(tache);

            NouvelleTacheTitre = string.Empty;
            NouvelleTacheCategorie = string.Empty;
            NouvelleTachePriorite = "Normale";
        }

        private bool PeutAjouterTache(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(NouvelleTacheTitre);
        }

        private void EnregistrerObjectif(object? parameter)
        {
            var objectif = _dbContext.Objectifs.FirstOrDefault();
            
            if (objectif == null)
            {
                // Si c'est la première fois, on le crée
                objectif = new Objectif { Texte = ObjectifSemaine };
                _dbContext.Objectifs.Add(objectif);
            }
            else
            {
                // Sinon on le met à jour
                objectif.Texte = ObjectifSemaine;
            }

            _dbContext.SaveChanges(); // Persistance sur le disque !
            MessageBox.Show("Objectif sauvegardé en base de données !", "Succès EF Core");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
