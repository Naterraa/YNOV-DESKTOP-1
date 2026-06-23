Reprendre la base du projet précédent ou en créer un nouveau.

Utiliser un BorderPane comme layout racine de votre Scene.

Dans la zone TOP : Ajouter un HBox contenant un titre textuel mis en valeur (ex: "Espace Connexion").

Dans la zone CENTER : Intégrer un GridPane parfaitement centré contenant :

- Un champ "Email" avec son champ de saisie textuel.
- Un champ "Mot de passe" avec son champ sécurisé.
- Un bouton "Se connecter" aligné à droite sous les champs.

Contrainte de réactivité : Lorsque vous redimensionnez la fenêtre, le formulaire doit obligatoirement rester centré et les espacements doivent rester harmonieux (interdiction d'utiliser le positionnement absolu).

---

**À savoir pour cet exercice :**

**Aligner le contenu d'une cellule spécifique dans le GridPane** : Pour positionner un nœud à droite dans sa colonne (par exemple le bouton), utilisez la méthode statique `GridPane.setHalignment()` avec la classe `HPos` :

```java
import javafx.geometry.HPos;

grid.add(monBouton, 1, 2);
GridPane.setHalignment(monBouton, HPos.RIGHT);
```

`HPos.RIGHT`, `HPos.LEFT` et `HPos.CENTER` permettent de contrôler l'alignement horizontal d'un nœud dans sa cellule.