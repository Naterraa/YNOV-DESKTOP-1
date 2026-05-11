using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Application_wpf.Models;

namespace Application_wpf.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string _appreciationGenerale = string.Empty;
    public string AppreciationGenerale
    {
        get => _appreciationGenerale;
        set { _appreciationGenerale = value; OnPropertyChanged(); }
    }

    private string _nouvelleMatiere = string.Empty;
    public string NouvelleMatiere
    {
        get => _nouvelleMatiere;
        set { _nouvelleMatiere = value; OnPropertyChanged(); }
    }

    private string _nouvelleValeur = string.Empty;
    public string NouvelleValeur
    {
        get => _nouvelleValeur;
        set { _nouvelleValeur = value; OnPropertyChanged(); }
    }

    private string _nouveauCoefficient = string.Empty;
    public string NouveauCoefficient
    {
        get => _nouveauCoefficient;
        set { _nouveauCoefficient = value; OnPropertyChanged(); }
    }

    public ObservableCollection<Note> Notes { get; set; }

    public ICommand AjouterNoteCommand { get; }
    public ICommand EnregistrerCommand { get; }

    public MainViewModel()
    {
        Notes = new ObservableCollection<Note>
        {
            new Note("Mathématiques", 15, 4, DateTime.Now),
            new Note("Physique", 12.5, 3, DateTime.Now),
            new Note("Informatique", 18, 5, DateTime.Now)
        };

        AppreciationGenerale = "Trimestre très satisfaisant dans l'ensemble. L'élève démontre un grand intérêt pour les matières scientifiques.";

        AjouterNoteCommand = new RelayCommand(ExecuteAjouterNote, CanExecuteAjouterNote);
        EnregistrerCommand = new RelayCommand(ExecuteEnregistrer);
    }

    private bool CanExecuteAjouterNote(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(NouvelleMatiere) && 
               double.TryParse(NouvelleValeur, out _) && 
               int.TryParse(NouveauCoefficient, out _);
    }

    private void ExecuteAjouterNote(object? parameter)
    {
        if (double.TryParse(NouvelleValeur, out double val) && int.TryParse(NouveauCoefficient, out int coef))
        {
            Notes.Add(new Note(NouvelleMatiere, val, coef, DateTime.Now));
            
            // Reset formulaire
            NouvelleMatiere = string.Empty;
            NouvelleValeur = string.Empty;
            NouveauCoefficient = string.Empty;
        }
    }

    private void ExecuteEnregistrer(object? parameter)
    {
        System.Windows.MessageBox.Show("Appréciation enregistrée : " + AppreciationGenerale);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
