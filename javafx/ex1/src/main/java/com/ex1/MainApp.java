package com.ex1;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.layout.StackPane;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.stage.Stage;

public class MainApp extends Application {

    @Override
    public void start(Stage primaryStage) {
        Label nameLabel = new Label("Romain Dinel");
        nameLabel.setFont(Font.font("Segoe UI", FontWeight.BOLD, 36));

        StackPane root = new StackPane(nameLabel);

        Scene scene = new Scene(root, 800, 450);
        primaryStage.setTitle("Exercice 1 - Présentation");
        primaryStage.setScene(scene);
        primaryStage.show();
        primaryStage.centerOnScreen();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
