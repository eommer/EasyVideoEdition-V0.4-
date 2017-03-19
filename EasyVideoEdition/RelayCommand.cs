using System;
using System.Windows.Input;

class RelayCommand : ICommand
{
    /// <summary>
    /// Class that describe a relay Command
    /// </summary>

    private Action function;
    private Predicate<Object> canExec;

    /// <summary>
    /// Create a relay command who launch the function f
    /// </summary>
    /// <param name="f">Function to use when the command is called</param>
    public RelayCommand(Action f)
    {
        this.function = f;
    }

    public RelayCommand(Action f, Predicate<Object> canExec)
    {
        this.function = f;
        this.canExec = canExec;
    }

    public bool CanExecute(object parameter)
    {
        if (this.canExec == null)
            return this.function != null;
        else
            return this.canExec(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
        if (this.function != null)
        {
            this.function();
        }
    }
}