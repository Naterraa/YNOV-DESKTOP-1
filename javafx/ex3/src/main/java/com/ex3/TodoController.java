package com.ex3;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;

/**
 * Contrôleur pour la vue de gestion de liste de tâches (Todo List).
 */
public class TodoController implements Initializable {

    @FXML
    private TextField taskInput;

    @FXML
    private ListView<String> listeNotesVisuelle;

    /**
     * Gère l'événement de clic sur le bouton d'ajout de tâche ou la touche Entrée.
     */
    @FXML
    private void handleAddTask(ActionEvent event) {
        String task = taskInput.getText();
        if (task != null && !task.trim().isEmpty()) {
            // Ajoute l'élément manuellement à la ListView
            listeNotesVisuelle.getItems().add(task.trim());
            // Vide le champ de saisie
            taskInput.clear();
            // Repose le focus sur le champ de saisie
            taskInput.requestFocus();
        }
    }

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // Initialisation de la vue si nécessaire
    }
}
