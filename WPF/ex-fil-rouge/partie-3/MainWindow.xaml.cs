using System;
using System.Collections.Generic;
using System.Windows;

namespace Application_wpf;

public class Note
{
    public string Matiere { get; set; }
    public double Valeur { get; set; }
    public int Coefficient { get; set; }
    public DateTime Date { get; set; }

    public Note(string matiere, double valeur, int coefficient, DateTime date)
    {
        Matiere = matiere;
        Valeur = valeur;
        Coefficient = coefficient;
        Date = date;
    }
}

public partial class MainWindow : Window
{
    public List<Note> currentNotes { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        // Ajout de 3 notes par défaut
        currentNotes = new List<Note>
        {
            new Note("Mathématiques", 15, 4, new DateTime(2026, 5, 10)),
            new Note("Physique", 12.5, 3, new DateTime(2026, 5, 12)),
            new Note("Informatique", 18, 5, new DateTime(2026, 5, 15))
        };

        // On définit le DataContext pour que le XAML puisse accéder aux propriétés
        this.DataContext = this;
    }
}