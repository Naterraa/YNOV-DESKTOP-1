using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Partie3
{
    public partial class MainWindow : Window
    {
        // Propriété qui contient la liste de nos tâches actuelles
        public List<Tache> CurrentTaches { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialisation de la liste avec 3 tâches par défaut
            CurrentTaches = new List<Tache>
            {
                new Tache { Titre = "Faire les courses", Priorite = "Haute", Categorie = "Personnel", DateCreation = DateTime.Now },
                new Tache { Titre = "Terminer le TP WPF", Priorite = "Normale", Categorie = "Études", DateCreation = DateTime.Now },
                new Tache { Titre = "Appeler le médecin", Priorite = "Basse", Categorie = "Santé", DateCreation = DateTime.Now }
            };

            // On lie la liste de tâches à la ListBox de l'interface
            TachesListBox.ItemsSource = CurrentTaches;
        }

        // Méthode déclenchée au clic sur le bouton "Ajouter"
        private void AjouterTache_Click(object sender, RoutedEventArgs e)
        {
            // Récupération des valeurs saisies dans les champs
            string titre = TitreTextBox.Text;
            string categorie = CategorieTextBox.Text;
            string priorite = ((ComboBoxItem)PrioriteComboBox.SelectedItem).Content.ToString() ?? "Normale";

            // Création de la nouvelle tâche
            Tache nouvelleTache = new Tache
            {
                Titre = titre,
                Priorite = priorite,
                Categorie = categorie,
                DateCreation = DateTime.Now
            };

            // On ajoute la tâche à notre liste
            CurrentTaches.Add(nouvelleTache);

            // Comme on utilise une List (et non une ObservableCollection), 
            // il faut forcer le rafraîchissement de la ListBox
            TachesListBox.Items.Refresh();
        }

        // Méthode déclenchée au clic sur le bouton "Enregistrer l'objectif"
        private void EnregistrerObjectif_Click(object sender, RoutedEventArgs e)
        {
            // Pour l'instant, on se contente d'afficher une boîte de dialogue
            // pour montrer que l'action est bien interceptée
            MessageBox.Show("Objectif mis à jour : " + ObjectifTextBox.Text, "Succès");
        }
    }
}