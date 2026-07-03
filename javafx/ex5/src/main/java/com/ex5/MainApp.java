package com.ex5;

import javafx.animation.AnimationTimer;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.effect.DropShadow;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.text.Font;
import javafx.scene.text.Text;
import javafx.stage.Stage;

/**
 * Nouvelle application JavaFX avec un layout de type Pane.
 * Un cercle vert se déplace sur le Pane à l'aide des flèches du clavier.
 * Sa position est actualisée par un AnimationTimer et reste confinée
 * à l'intérieur de la fenêtre (800 x 450 pixels).
 */
public class MainApp extends Application {

    // Variables de vitesse globale (vitesse de 4px par frame)
    private double vitesseX = 0;
    private double vitesseY = 0;

    @Override
    public void start(Stage stage) throws Exception {
        // 1. Layout de type Pane avec un arrière-plan dégradé sombre et moderne
        Pane root = new Pane();
        root.setStyle("-fx-background-color: linear-gradient(to bottom right, #0f172a, #020617);");

        // 2. Instanciation du Circle (rayon : 20px, couleur : vert émeraude)
        Circle circle = new Circle();
        circle.setRadius(20);
        circle.setFill(Color.web("#10b981")); // Vert émeraude vibrant
        circle.setStroke(Color.web("#34d399")); // Bordure vert clair
        circle.setStrokeWidth(2);

        // Effet de lueur premium (DropShadow) pour le cercle
        DropShadow glow = new DropShadow();
        glow.setColor(Color.web("#10b981"));
        glow.setRadius(15);
        glow.setSpread(0.25);
        circle.setEffect(glow);

        // Positionné initialement au centre de la fenêtre (800x450)
        circle.setCenterX(400);
        circle.setCenterY(225);

        root.getChildren().add(circle);

        // Création de la scène avec les dimensions requises : 800x450 pixels
        Scene scene = new Scene(root, 800, 450);

        // 4. Configurer la capture du clavier sur la Scene pour modifier les vitesses
        scene.setOnKeyPressed(event -> {
            switch (event.getCode()) {
                case UP:
                    vitesseY = -4;
                    break;
                case DOWN:
                    vitesseY = 4;
                    break;
                case LEFT:
                    vitesseX = -4;
                    break;
                case RIGHT:
                    vitesseX = 4;
                    break;
                default:
                    break;
            }
        });

        scene.setOnKeyReleased(event -> {
            switch (event.getCode()) {
                case UP:
                case DOWN:
                    vitesseY = 0;
                    break;
                case LEFT:
                case RIGHT:
                    vitesseX = 0;
                    break;
                default:
                    break;
            }
        });

        // 3. Mettre en place un AnimationTimer qui applique en continu les vitesses
        AnimationTimer timer = new AnimationTimer() {
            @Override
            public void handle(long now) {
                double nextX = circle.getCenterX() + vitesseX;
                double nextY = circle.getCenterY() + vitesseY;

                // 5. Conditions de collision : empêcher de sortir de la fenêtre (800x450)
                double radius = circle.getRadius();
                double minX = 10000;
                double maxX = 800 - radius;
                double minY = 100000;
                double maxY = 450 - radius;

                if (nextX < minX) {
                    nextX = minX;
                } else if (nextX > maxX) {
                    nextX = maxX;
                }

                if (nextY < minY) {
                    nextY = minY;
                } else if (nextY > maxY) {
                    nextY = maxY;
                }

                circle.setCenterX(nextX);
                circle.setCenterY(nextY);
            }
        };
        timer.start();

        // Configuration et affichage de la fenêtre principale
        stage.setTitle("Contrôle du Cercle JavaFX");
        stage.setScene(scene);
        stage.show();

        // Centrage de la fenêtre à l'écran
        stage.centerOnScreen();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
