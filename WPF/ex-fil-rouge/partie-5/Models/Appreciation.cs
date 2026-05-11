using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Application_wpf.Models;

public class Appreciation : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _texte = string.Empty;
    public string Texte
    {
        get => _texte;
        set { _texte = value; OnPropertyChanged(); }
    }

    public Appreciation() { }

    public Appreciation(string texte)
    {
        Texte = texte;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
