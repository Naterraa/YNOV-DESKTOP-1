package com.ex2;

import javafx.application.Application;
import javafx.geometry.HPos;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;

/**
 * Classe principale de l'application de connexion JavaFX.
 * Elle utilise un BorderPane comme racine, un HBox au TOP pour le titre,
 * et un GridPane réactif au CENTER pour le formulaire de connexion.
 */
public class MainApp extends Application {

    @Override
    public void start(Stage stage) {
        // Layout racine : BorderPane
        BorderPane root = new BorderPane();

        // Style premium : Dégradé radial sombre pour le fond global
        root.setStyle("-fx-background-color: radial-gradient(center 50% 50%, radius 75%, #0f172a 0%, #020617 100%);");

        // --- ZONE TOP : HBox avec titre mis en valeur ---
        HBox topBox = new HBox();
        topBox.setAlignment(Pos.CENTER);
        topBox.setPadding(new Insets(45, 20, 15, 20));

        Text titleText = new Text("Espace Connexion");
        titleText.setFont(Font.font("Segoe UI", FontWeight.BOLD, 30));
        // Effet de dégradé sur le texte avec une ombre lumineuse violette en
        // arrière-plan
        titleText.setStyle("-fx-fill: linear-gradient(from 0% 0% to 100% 0%, #3b82f6 0%, #8b5cf6 100%);" +
                "-fx-effect: dropshadow(three-pass-box, rgba(139, 92, 246, 0.4), 15, 0, 0, 0);");

        topBox.getChildren().add(titleText);
        root.setTop(topBox);

        // --- ZONE CENTER : GridPane parfaitement centré (formulaire de connexion) ---
        GridPane grid = new GridPane();
        grid.setAlignment(Pos.CENTER); // Centrage automatique horizontal et vertical
        grid.setHgap(15);
        grid.setVgap(18);
        grid.setPadding(new Insets(35, 45, 35, 45));

        // Design de la carte du formulaire : Glassmorphism élégant
        grid.setStyle("-fx-background-color: rgba(30, 41, 59, 0.65);" +
                "-fx-background-radius: 16px;" +
                "-fx-border-color: rgba(255, 255, 255, 0.08);" +
                "-fx-border-radius: 16px;" +
                "-fx-border-width: 1px;" +
                "-fx-effect: dropshadow(three-pass-box, rgba(0, 0, 0, 0.5), 30, 0, 0, 15);");

        // Champ Email
        Label emailLabel = new Label("Email");
        emailLabel.setFont(Font.font("Segoe UI", FontWeight.SEMI_BOLD, 14));
        emailLabel.setStyle("-fx-text-fill: #94a3b8;");

        TextField emailField = new TextField();
        emailField.setPromptText("Ex: romain.dinel@example.com");
        emailField.setPrefWidth(280);
        emailField.setStyle("-fx-background-color: #1e293b;" +
                "-fx-text-fill: #f8fafc;" +
                "-fx-prompt-text-fill: #64748b;" +
                "-fx-background-radius: 8px;" +
                "-fx-border-color: #334155;" +
                "-fx-border-radius: 8px;" +
                "-fx-border-width: 1.5px;" +
                "-fx-padding: 10px;");

        // Champ Mot de passe
        Label passwordLabel = new Label("Mot de passe");
        passwordLabel.setFont(Font.font("Segoe UI", FontWeight.SEMI_BOLD, 14));
        passwordLabel.setStyle("-fx-text-fill: #94a3b8;");

        PasswordField passwordField = new PasswordField();
        passwordField.setPromptText("••••••••");
        passwordField.setPrefWidth(280);
        passwordField.setStyle("-fx-background-color: #1e293b;" +
                "-fx-text-fill: #f8fafc;" +
                "-fx-prompt-text-fill: #64748b;" +
                "-fx-background-radius: 8px;" +
                "-fx-border-color: #334155;" +
                "-fx-border-radius: 8px;" +
                "-fx-border-width: 1.5px;" +
                "-fx-padding: 10px;");

        // Bouton de connexion
        Button loginButton = new Button("Se connecter");
        loginButton.setFont(Font.font("Segoe UI", FontWeight.BOLD, 14));
        loginButton.setStyle("-fx-background-color: linear-gradient(from 0% 0% to 100% 0%, #2563eb 0%, #4f46e5 100%);" +
                "-fx-text-fill: #ffffff;" +
                "-fx-background-radius: 8px;" +
                "-fx-padding: 10px 24px;" +
                "-fx-cursor: hand;" +
                "-fx-font-weight: bold;");

        // Ajout des éléments au GridPane
        grid.add(emailLabel, 0, 0);
        grid.add(emailField, 1, 0);
        grid.add(passwordLabel, 0, 1);
        grid.add(passwordField, 1, 1);
        grid.add(loginButton, 1, 2);

        // Alignement du bouton à droite sous les champs
        GridPane.setHalignment(loginButton, HPos.RIGHT);
        // Placement du formulaire dans le centre du BorderPane
        root.setCenter(grid);

        // Définition de la scène et affichage de la fenêtre (800 x 450 pixels)
        Scene scene = new Scene(root, 800, 450);
        stage.setTitle("Espace Connexion");
        stage.setScene(scene);
        stage.show();

        // Centrage de la fenêtre sur l'écran
        stage.centerOnScreen();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
