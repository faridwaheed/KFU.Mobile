
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KFU.Mobile.Validators;
using Xamarin.Forms;

namespace KFU.Mobile.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected bool _isBusy;
        protected bool _isVisible;

        protected Validator _validator;
        protected List<Command> _changeCanExecuteCommands;
        protected List<Command> _forgetPasswordExecuteCommands;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase(View mainContainer = null)
        {
            _isBusy = false;
            _validator = new Validator(mainContainer);
            _changeCanExecuteCommands = new List<Command>();
            _forgetPasswordExecuteCommands = new List<Command>();
        }

        public virtual bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetValue(ref _isBusy, value);
                foreach (Command command in _changeCanExecuteCommands)
                {
                    command.ChangeCanExecute();
                }
                foreach (Command command in _forgetPasswordExecuteCommands)
                {
                    command.ChangeCanExecute();
                }
            }
        }

        public virtual bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                SetValue(ref _isVisible, value);
                foreach (Command command in _changeCanExecuteCommands)
                {
                    command.ChangeCanExecute();
                }
            }
        }

        protected void SetValue<T>(ref T oldValue, T newValue, [CallerMemberName]string name = "")
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValue = newValue;
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
}
