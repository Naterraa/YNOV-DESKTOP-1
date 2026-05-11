using System.Windows;
using Application_wpf.ViewModels;

namespace Application_wpf;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        
        _viewModel = new MainViewModel();
        this.DataContext = _viewModel;

        // On utilise l'événement Loaded pour déclencher le chargement asynchrone des données
        this.Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        await _viewModel.LoadDataAsync();
    }
}