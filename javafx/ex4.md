Reprendre le code de la Todo List de la partie précédente.  
Supprimer toute manipulation directe des composants dans votre méthode de clic (interdiction d'utiliser listeNotesVisuelle.getItems().add(...) ou inputNote.setText("")).  

Dans le contrôleur, déclarer : 
- Une propriété StringProperty texteSaisi.  
- Une ObservableList<String> listeNotes.  

Dans la méthode initialize(), mettre en place les Bindings requis:  
- Lier de manière bidirectionnelle le TextField à texteSaisi.  
- Lier la ListView à listeNotes.  

Désactiver le bouton d'ajout si texteSaisi est vide (utiliser la méthode isEmpty() de la propriété).Adapter la méthode d'action : elle doit simplement ajouter le contenu de texteSaisi.get() à listeNotes, puis réinitialiser texteSaisi.set(""). 

Vérifier que l'application fonctionne de manière fluide et transparente.