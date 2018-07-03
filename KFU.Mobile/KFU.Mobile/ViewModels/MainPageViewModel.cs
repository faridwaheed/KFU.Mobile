using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using KFU.Mobile.Helpers;
using KFU.Mobile.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace KFU.Mobile.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ICommand tapCommand;
        public MainPageViewModel()
        {
            tapCommand = new Command(OnTapped);
           
        }
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        void OnTapped(object s)
        {
            NavigationHelper.NavigateAsync(new SchoolSchedulePage());
        }

       
        //region INotifyPropertyChanged code omitted
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
