using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;
using Application_wpf.Models;

namespace Application_wpf.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly NotesDbContext _context;
    private Appreciation? _currentAppreciation; // Pour garder la référence de l'objet DB

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
        _context = new NotesDbContext();
        
        // Chargement des notes depuis la base de données
        var notesFromDb = _context.Notes.ToList();
        Notes = new ObservableCollection<Note>(notesFromDb);

        // Chargement de l'appréciation générale depuis la base de données
        _currentAppreciation = _context.Appreciations.FirstOrDefault();
        
        if (_currentAppreciation != null)
        {
            AppreciationGenerale = _currentAppreciation.Texte;
        }
        else
        {
            AppreciationGenerale = "Trimestre très satisfaisant dans l'ensemble. L'élève démontre un grand intérêt pour les matières scientifiques.";
        }

        AjouterNoteCommand = new RelayCommand(ExecuteAjouterNote, CanExecuteAjouterNote);
        EnregistrerCommand = new RelayCommand(ExecuteEnregistrer);
    }

    private bool CanExecuteAjouterNote(object? parameter) {
        return !string.IsNullOrWhiteSpace(NouvelleMatiere) && 
               double.TryParse(NouvelleValeur, out _) && 
               int.TryParse(NouveauCoefficient, out _);
    }

    private void ExecuteAjouterNote(object? parameter) {
        if (double.TryParse(NouvelleValeur, out double val) && int.TryParse(NouveauCoefficient, out int coef))  {
            var nouvelleNote = new Note(NouvelleMatiere, val, coef, DateTime.Now);
            
            _context.Notes.Add(nouvelleNote);
            _context.SaveChanges();

            Notes.Add(nouvelleNote);
            
            // Reset formulaire
            NouvelleMatiere = string.Empty;
            NouvelleValeur = string.Empty;
            NouveauCoefficient = string.Empty;
        }
    }

    private void ExecuteEnregistrer(object? parameter)
    {
        if (_currentAppreciation == null)
        {
            // S'il n'y avait pas d'appréciation en base, on la crée
            _currentAppreciation = new Appreciation(AppreciationGenerale);
            _context.Appreciations.Add(_currentAppreciation);
        }
        else
        {
            // Sinon on met juste à jour le texte
            _currentAppreciation.Texte = AppreciationGenerale;
        }

        _context.SaveChanges();
        System.Windows.MessageBox.Show("Appréciation enregistrée en base de données !");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
