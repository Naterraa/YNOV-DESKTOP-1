# Isoler l'accès aux données (Services) et asynchronisme

- Créer un dossier `Services` à la racine du projet.
- Créer une classe `NotesService.cs` dans ce dossier. Cette classe aura la responsabilité exclusive d'interagir avec `NotesDbContext`.
- Implémenter des méthodes asynchrones dans `NotesService` pour gérer les opérations CRUD sans bloquer l'interface : 
  - `Task<List<Note>> GetNotesAsync()`
  - `Task AddNoteAsync(Note note)`
  - `Task<Appreciation?> GetAppreciationAsync()`
  - `Task SaveAppreciationAsync(Appreciation appreciation)`
- Modifier `MainViewModel.cs` pour qu'il n'utilise plus directement `NotesDbContext`, mais qu'il instancie et utilise `NotesService`.
- L'interface UI (WPF) étant sur le thread principal, le chargement des données dans le constructeur n'est pas idéal. Créer une méthode `LoadDataAsync()` dans le ViewModel.
- Utiliser l'événement `Loaded` de la fenêtre (dans le code-behind `MainWindow.xaml.cs`) pour appeler cette méthode de chargement au démarrage de l'application.
- Mettre à jour les commandes d'ajout et d'enregistrement pour qu'elles deviennent asynchrones et utilisent le nouveau service.
