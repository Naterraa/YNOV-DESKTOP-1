using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Application_wpf.Models;

public class Note : INotifyPropertyChanged
{
    private string _matiere = string.Empty;
    public string Matiere
    {
        get => _matiere;
        set { _matiere = value; OnPropertyChanged(); }
    }

    private double _valeur;
    public double Valeur
    {
        get => _valeur;
        set { _valeur = value; OnPropertyChanged(); }
    }

    private int _coefficient;
    public int Coefficient
    {
        get => _coefficient;
        set { _coefficient = value; OnPropertyChanged(); }
    }

    private DateTime _date;
    public DateTime Date
    {
        get => _date;
        set { _date = value; OnPropertyChanged(); }
    }

    public Note(string matiere, double valeur, int coefficient, DateTime date)
    {
        Matiere = matiere;
        Valeur = valeur;
        Coefficient = coefficient;
        Date = date;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
