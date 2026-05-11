using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Partie6.Models;
using Partie6.Services;

namespace Partie6.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // On n'utilise plus TodoDbContext directement, on passe par le service métier.
        private readonly TodoService _todoService;

        public ObservableCollection<Tache> Taches { get; set; } = new ObservableCollection<Tache>();

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
            _todoService = new TodoService();

            // Note : on ne charge plus les données dans le constructeur car un constructeur 
            // ne peut pas être asynchrone et cela bloquerait l'interface.
            // On le fera via la méthode LoadDataAsync appelée par la vue.

            // Utilisation d'une expression lambda async pour exécuter du code asynchrone dans un RelayCommand classique
            AjouterTacheCommand = new RelayCommand(async (param) => await AjouterTacheAsync(), PeutAjouterTache);
            EnregistrerObjectifCommand = new RelayCommand(async (param) => await EnregistrerObjectifAsync());
        }

        // Méthode appelée depuis MainWindow.xaml.cs lors de l'événement Loaded
        public async Task LoadDataAsync()
        {
            // Récupération asynchrone
            var taches = await _todoService.GetTachesAsync();
            Taches.Clear();
            foreach (var t in taches)
            {
                Taches.Add(t);
            }

            var objectif = await _todoService.GetObjectifAsync();
            if (objectif != null)
            {
                ObjectifSemaine = objectif.Texte;
            }
        }

        private async Task AjouterTacheAsync()
        {
            var tache = new Tache
            {
                Titre = NouvelleTacheTitre,
                Categorie = NouvelleTacheCategorie,
                Priorite = NouvelleTachePriorite,
                DateCreation = DateTime.Now
            };

            // Sauvegarde via le service asynchrone
            await _todoService.AddTacheAsync(tache);

            // Mise à jour de l'UI
            Taches.Add(tache);

            NouvelleTacheTitre = string.Empty;
            NouvelleTacheCategorie = string.Empty;
            NouvelleTachePriorite = "Normale";
        }

        private bool PeutAjouterTache(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(NouvelleTacheTitre);
        }

        private async Task EnregistrerObjectifAsync()
        {
            var objectif = new Objectif { Texte = ObjectifSemaine };
            
            // On confie toute la logique (création ou mise à jour) au service
            await _todoService.SaveObjectifAsync(objectif);
            
            MessageBox.Show("Objectif sauvegardé en arrière-plan avec succès !", "Service Asynchrone");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
