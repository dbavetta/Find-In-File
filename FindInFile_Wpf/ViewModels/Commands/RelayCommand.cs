using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FindInFile.Wpf.ViewModels.Commands
{
    /// <summary>
    /// Usage within view model: 
    ///     public ICommand Command { get; set; }
    ///     public ViewModel() { this.Command = new RelayCommand(ExecuteCommand, CanExecuteCommand); }
    ///     public void ExecuteCommand(object parameter) { }
    ///     public bool CanExecuteCommand(object parameter) { return true; }
    /// </summary>

    public class RelayCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute m_Execute;
        private ICommandOnCanExecute m_CanExecute;

        public RelayCommand(ICommandOnExecute onExecuteMethod)
        {
            m_Execute = onExecuteMethod;
            m_CanExecute = ReturnTrue;
        }

        public RelayCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            m_Execute = onExecuteMethod;
            m_CanExecute = onCanExecuteMethod;
        }

        #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return m_CanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            m_Execute.Invoke(parameter);
        }

        private bool ReturnTrue(object parameter)
        {
            return true;
        }
        #endregion
    }
}
