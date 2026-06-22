# TP : Gestionnaire de Séries TV

## Objectif du TP
Réaliser une application WPF complète permettant de gérer une liste de séries TV. L'application devra respecter l'architecture **MVVM**, utiliser **Entity Framework Core (SQLite)** pour la persistance des données, et isoler l'accès aux données de manière **asynchrone** via une couche de **Service**.

## Spécifications de la vue
- La fenêtre principale (intitulée "Gestionnaire de Séries TV") doit être divisée en deux colonnes (la colonne de droite étant plus large que celle de gauche).
- **Colonne de gauche :**
  - Un titre "Mes Séries".
  - Une liste (`ListBox`) affichant les séries enregistrées. Le `SelectedItem` de cette liste doit être lié (`Binding`) au ViewModel.
  - Un formulaire d'ajout en bas comprenant 3 champs de saisie (`TextBox`) pour le **Titre**, le **Nombre de saisons**, et l'**Année de sortie**, ainsi qu'un bouton "Ajouter".
- **Colonne de droite (Détails de la série sélectionnée) :**
  - Cette zone ne doit afficher des informations que si une série est sélectionnée dans la liste à gauche.
  - Afficher les détails modifiables de la série (Titre, Saisons, Année).
  - Une large zone de texte multiligne (`TextBox`) pour rédiger l'**avis personnel** sur la série sélectionnée.
  - Un bouton "Enregistrer les modifications" pour sauvegarder les éditions de la série.
  - Un bouton "Supprimer cette série" (en rouge de préférence).

## Spécifications Techniques
- **Modèle de données (`Models`) :** 
  - Une classe `Serie` avec les champs : `Id`, `Titre`, `Saisons`, `Annee`, `DateAjout` et `Avis` (pour stocker la critique personnelle de cette série précise).
- **Base de données :**
  - Utiliser Entity Framework Core avec SQLite (`Microsoft.EntityFrameworkCore.Sqlite`).
  - La base de données locale (`series.db`) doit être configurée et générée via les migrations (`DbContext`, `DbSet<Serie>`).
- **Couche Service (`Services`) :**
  - Créer une classe `SeriesService` qui centralise et isole tous les accès au `DbContext`.
  - Toutes les opérations CRUD exposées par ce service (récupération de la liste `GetSeriesAsync`, ajout `AddSerieAsync`, modification `UpdateSerieAsync` et suppression `DeleteSerieAsync`) doivent être **asynchrones** (`Task`).
- **Architecture MVVM (`ViewModels`) :**
  - Mettre en place un `MainViewModel` (implémentant `INotifyPropertyChanged`).
  - Gérer une propriété `SelectedSerie` qui reflète la sélection de la `ListBox`.
  - Utiliser une `ObservableCollection<Serie>` pour lier dynamiquement l'interface à la liste des données.
  - Les actions des boutons ("Ajouter", "Enregistrer les modifications", "Supprimer") doivent être gérées par des commandes (`RelayCommand`) asynchrones.
  - Le chargement initial des données depuis la base SQLite doit se faire de manière asynchrone au démarrage de l'application (événement `Loaded`).
