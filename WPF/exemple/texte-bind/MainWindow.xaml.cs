using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace texte_bind;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged {

    // Événement requis par INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    // On utilise CallerMemberName pour éviter de taper le nom de la propriété
    private void OnPropertyChanged([CallerMemberName] string? nom = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nom));

    // Propriété avec notification

    // underscore pour différencier le champ privé du champ public
    private string _monText = string.Empty;
    public string MonText { get => _monText;
        set {
            _monText = value;
            OnPropertyChanged();
        }
    }

    public MainWindow() {
        InitializeComponent();
        this.DataContext = this;
    }
}