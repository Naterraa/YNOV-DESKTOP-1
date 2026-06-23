Générer un projet vide Java 21+ en utilisant votre gestionnaire de dépendances (Maven ou Gradle).

Ajouter les dépendances nécessaires pour javafx-controls.Créer le fichier module-info.java requis à la racine de votre package principal.

Écrire la classe principale étendant Application.Configurer votre Stage pour qu'il s'ouvre au centre de l'écran avec une taille par défaut de $800 \times 450$ pixels, 
contenant un texte affichant votre prénom et votre nom au centre de la fenêtre.

---

**À savoir pour cet exercice :**

**Créer le projet Maven** : Dans votre IDE, créer un projet JavaFX avec Maven. Le `pom.xml` doit déclarer la dépendance suivante :

```xml
<dependency>
    <groupId>org.openjfx</groupId>
    <artifactId>javafx-controls</artifactId>
    <version>21</version>
</dependency>
```

**Centrer la fenêtre sur l'écran** : La méthode `centerOnScreen()` s'appelle sur le `Stage` après `show()` :

```java
stage.show();
stage.centerOnScreen();
```