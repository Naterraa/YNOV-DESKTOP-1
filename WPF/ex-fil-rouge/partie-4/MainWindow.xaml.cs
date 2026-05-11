using System.Windows;
using Application_wpf.ViewModels;

namespace Application_wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Affectation du ViewModel au DataContext
        this.DataContext = new MainViewModel();
    }
}