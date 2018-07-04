using System;
using System.Collections.Generic;
using System.Text;
using KFU.Mobile.AppServices;
using KFU.Mobile.Helpers;
using KFU.Mobile.Resources.Regex;
using KFU.Mobile.Validators;
using KFU.Mobile.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace KFU.Mobile.ViewModels
{
   public class SchoolScheduleViewModel : ViewModelBase, IValidatableViewModel
    {

            private string _userId;
            private string _password;

            public SchoolScheduleViewModel()
            {

                LoginUserCommand = new Command(Login, () => !IsBusy);
                _changeCanExecuteCommands.Add(LoginUserCommand);
                var saved = LoginUserCommand;

            }


            public string UserId
            {
                get { return _userId; }
                set { SetValue(ref _userId, value); }
            }

            public string Password
            {
                get { return _password; }
                set
                {
                    SetValue(ref _password, value);
                }
            }
           
            public Command LoginUserCommand { get; }
            private async void Login()
            {
                await App.Current.MainPage.Navigation.PushPopupAsync(new LoadingPopup());
               
                await App.Current.MainPage.Navigation.PopPopupAsync(true);
                //IsBusy = false;
            }


        public void ConfigureValidationRules()
        {
            throw new NotImplementedException();
        }
    }
    }
