using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Application_wpf.Models;
using Application_wpf.Services;

namespace Application_wpf.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly NotesService _notesService;
    private Appreciation? _currentAppreciation;

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

    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

    public ICommand AjouterNoteCommand { get; }
    public ICommand EnregistrerCommand { get; }

    public MainViewModel()
    {
        _notesService = new NotesService();
        
        // On utilise async void (via lambda) pour l'exécution des commandes
        AjouterNoteCommand = new RelayCommand(async (param) => await ExecuteAjouterNoteAsync(), CanExecuteAjouterNote);
        EnregistrerCommand = new RelayCommand(async (param) => await ExecuteEnregistrerAsync());
    }

    public async Task LoadDataAsync()
    {
        // Chargement asynchrone des notes
        var notesFromDb = await _notesService.GetNotesAsync();
        Notes.Clear();
        foreach (var note in notesFromDb)
        {
            Notes.Add(note);
        }

        // Chargement asynchrone de l'appréciation
        _currentAppreciation = await _notesService.GetAppreciationAsync();
        
        if (_currentAppreciation != null)
        {
            AppreciationGenerale = _currentAppreciation.Texte;
        }
        else
        {
            AppreciationGenerale = "Trimestre très satisfaisant dans l'ensemble. L'élève démontre un grand intérêt pour les matières scientifiques.";
        }
    }

    private bool CanExecuteAjouterNote(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(NouvelleMatiere) && 
               double.TryParse(NouvelleValeur, out _) && 
               int.TryParse(NouveauCoefficient, out _);
    }

    private async Task ExecuteAjouterNoteAsync()
    {
        if (double.TryParse(NouvelleValeur, out double val) && int.TryParse(NouveauCoefficient, out int coef))
        {
            var nouvelleNote = new Note(NouvelleMatiere, val, coef, DateTime.Now);
            
            // 1. Ajout en base via le service (asynchrone)
            await _notesService.AddNoteAsync(nouvelleNote);

            // 2. Mise à jour UI
            Notes.Add(nouvelleNote);
            
            // Reset formulaire
            NouvelleMatiere = string.Empty;
            NouvelleValeur = string.Empty;
            NouveauCoefficient = string.Empty;
        }
    }

    private async Task ExecuteEnregistrerAsync()
    {
        if (_currentAppreciation == null)
        {
            _currentAppreciation = new Appreciation(AppreciationGenerale);
        }
        else
        {
            _currentAppreciation.Texte = AppreciationGenerale;
        }

        await _notesService.SaveAppreciationAsync(_currentAppreciation);
        System.Windows.MessageBox.Show("Appréciation enregistrée en base de données !");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
