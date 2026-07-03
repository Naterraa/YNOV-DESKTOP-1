package com.ex3;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 * Classe principale de l'application de Liste de Tâches JavaFX.
 * Charge l'interface depuis le fichier FXML todo-view.fxml.
 */
public class MainApp extends Application {

    @Override
    public void start(Stage stage) throws Exception {
        // Chargement du FXML depuis les ressources
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/todo-view.fxml"));
        Parent root = loader.load();

        // Création de la scène avec les dimensions requises : 800x450 pixels
        Scene scene = new Scene(root, 800, 450);

        // Configuration de la fenêtre principale
        stage.setTitle("Ma Liste de Tâches");
        stage.setScene(scene);
        stage.show();

        // Centrage de la fenêtre à l'écran
        stage.centerOnScreen();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
