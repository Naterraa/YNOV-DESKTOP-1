Créer une nouvelle application JavaFX avec un layout de type Pane (conteneur libre qui autorise les positions dynamiques modifiées par le code). Contrairement aux interfaces applicatives, les jeux et animations modifient les positions par le code à chaque frame : l'interdiction du positionnement absolu ne s'applique pas ici.

Instancier et ajouter au Pane un objet Circle (rayon : 20px, couleur : vert), positionné initialement au centre.Mettre en place un AnimationTimer qui applique en continu deux variables de vitesse globale : 
vitesseX et vitesseY.

Configurer la capture du clavier sur la Scene pour modifier ces variables de vitesse avec les flèches directionnelles (vitesse de 4px par frame).

Ajouter une condition de collision avec les bordures : Empêcher le cercle de sortir des limites de la fenêtre ($800 \times 450$ pixels). Si le cercle atteint un bord, sa position doit être bloquée.

---

**À savoir pour cet exercice :**

**Le layout `Pane`** : Contrairement à `HBox` ou `VBox`, un `Pane` place ses enfants selon leurs coordonnées propres sans disposition automatique. C'est le conteneur adapté aux jeux et animations :

```java
Pane root = new Pane();
root.getChildren().add(monCircle);
```

**Positionner un `Circle`** : Un cercle se positionne via `setCenterX()` / `setCenterY()` (coordonnées de son centre) et se lit via `getCenterX()` / `getCenterY()` :

```java
circle.setCenterX(400); // centre horizontal initial
circle.setCenterY(225); // centre vertical initial
```

**Collision avec les bordures (clamping)** : Pour bloquer un objet aux limites de la fenêtre, calculez la prochaine position avant de l'appliquer, et corrigez-la si elle dépasse les bords. Pensez à tenir compte du rayon pour que le cercle ne sorte pas à moitié :

```java
double nextX = circle.getCenterX() + vitesseX;
double rayon  = circle.getRadius();

if (nextX < rayon)          nextX = rayon;           // bord gauche
if (nextX > 800 - rayon)    nextX = 800 - rayon;     // bord droit

circle.setCenterX(nextX);
```

Appliquez la même logique sur l'axe Y avec les limites `rayon` et `450 - rayon`.