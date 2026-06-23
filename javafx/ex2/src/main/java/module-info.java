/**
 * Définition du module pour l'application JavaFX.
 * Ce fichier configure l'accès aux modules JavaFX nécessaires.
 */
module com.ex2 {
    // Dépendances requises par le module
    requires javafx.controls;
    requires javafx.graphics;
    requires javafx.fxml;
    requires javafx.media;

    // Autorise la réflexion pour javafx.fxml sur le package com.ex2
    opens com.ex2 to javafx.fxml;
    
    // Exporte le package com.ex2 pour qu'il soit accessible par d'autres modules (dont JavaFX)
    exports com.ex2;
}