using System;
using System.Windows.Input;

namespace Partie4.ViewModels
{
    // RelayCommand est une classe utilitaire standard en WPF MVVM.
    // Elle permet de relier une action (méthode) d'un ViewModel 
    // à un événement de l'interface graphique (comme le clic d'un bouton).
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        // Événement requis par l'interface ICommand, déclenché quand 
        // les conditions d'exécution de la commande changent.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Vérifie si la commande a le droit de s'exécuter
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Exécute l'action de la commande
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
