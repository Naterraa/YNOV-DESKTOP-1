using System.Windows;
using Partie6.ViewModels;

namespace Partie6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // On affecte le DataContext ici plutôt qu'en XAML pour l'avoir sous la main facilement
            this.DataContext = new MainViewModel();
        }

        // Cette méthode est appelée quand la fenêtre a fini de se dessiner à l'écran
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainViewModel viewModel)
            {
                // On déclenche le chargement asynchrone. 
                // L'interface reste fluide pendant que la base de données travaille !
                await viewModel.LoadDataAsync();
            }
        }
    }
}