Dans votre projet, créer un sous-dossier resources pour y placer un fichier nommé todo-view.fxml.Concevoir l'interface suivante en FXML (à la main ou via Scene Builder) encadrée par une VBox :

- Un TextField pour saisir une nouvelle tâche.
- Un Button textuel "Ajouter à la liste".
- Une ListView (pensez à lui attribuer un fx:id="listeNotesVisuelle") placée en bas.  

Créer une classe TodoController et lier votre FXML à celle-ci.Coder la méthode d'événement du bouton : au clic, récupérez le texte du champ de saisie, ajoutez-le manuellement à la ListView par le code, puis videz le champ

---

**À savoir pour cet exercice :**

**Ajouter un élément à une ListView manuellement** : Chaque `ListView` expose sa liste interne via `getItems()`. Vous pouvez y ajouter ou supprimer des éléments directement par le code :

```java
// Ajouter un élément
maListView.getItems().add("Nouvelle tâche");

// Vider la liste
maListView.getItems().clear();
```

Note : c'est l'approche naïve de cet exercice. Elle sera remplacée dans l'exercice suivant par une `ObservableList` liée par binding, qui supprime toute manipulation directe du composant graphique.
