/**
 * Définition du module pour l'application JavaFX.
 * Ce fichier configure l'accès aux modules JavaFX nécessaires.
 */
module com.ex1 {
    requires javafx.controls;
    requires javafx.fxml;

    opens com.ex1 to javafx.fxml;
    exports com.ex1;
}