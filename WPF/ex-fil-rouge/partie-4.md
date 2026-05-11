# Appliquer une bonne pratique

- Créer un dossier Models, ViewModels et Views
- Créer MainViewModel.cs dans ViewModels. Il doit contenir ObservableCollection<Note> 
- Implémenter la logique du bouton "Enregistrer" et "Ajouter une note" dans des commandes ICommand : Enregistrer pour mettre à jour l'appréciation générale en affichant un message de validation format popup et ajouter une note pour ajouter une note à la liste. Pour le moment ce n'est pas persistant
- Lier la ListBox avec l'ObservableCollection<Note>

- Proposition de fichiers : dossier views vide, dossier viewmodels avec fichier MainViewModel.cs et fichier RelayCommand.cs, dossier models avec fichier Note.cs (pas forcément le plus professionnel, mais pour une première approche du MVVM c'est bien)