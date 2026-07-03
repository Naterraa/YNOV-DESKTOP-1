/**
 * Définition du module pour l'application JavaFX.
 * Ce fichier configure l'accès aux modules JavaFX nécessaires.
 */
module com.ex5 {
    // Dépendances requises par le module
    requires javafx.controls;
    requires javafx.graphics;
    requires javafx.fxml;
    requires javafx.media;

    // Exporte le package com.ex5 pour qu'il soit accessible par d'autres modules (dont JavaFX)
    exports com.ex5;
}