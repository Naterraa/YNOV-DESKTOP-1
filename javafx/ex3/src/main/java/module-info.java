/**
 * Définition du module pour l'application JavaFX.
 * Ce fichier configure l'accès aux modules JavaFX nécessaires.
 */
module com.ex3 {
    // Dépendances requises par le module
    requires javafx.controls;
    requires javafx.graphics;
    requires javafx.fxml;
    requires javafx.media;

    // Autorise la réflexion pour javafx.fxml sur le package com.ex3
    opens com.ex3 to javafx.fxml;
    
    // Exporte le package com.ex3 pour qu'il soit accessible par d'autres modules (dont JavaFX)
    exports com.ex3;
}