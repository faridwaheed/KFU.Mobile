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
   public class LoginPageViewModel : ViewModelBase, IValidatableViewModel
    {

            private string _email;
            private string _password;

            public LoginPageViewModel(View mainContainer) : base(mainContainer)
            {

                LoginUserCommand = new Command(Login, () => !IsBusy);
                _changeCanExecuteCommands.Add(LoginUserCommand);
                var saved = LoginUserCommand;

                ConfigureValidationRules();
            }

            // Islam 
            public bool ReturnToReservePlayground { get; set; }

            public string AccessCode { get; set; }


            public string Email
            {
                get { return _email; }
                set { SetValue(ref _email, value); }
                //SetValue(await AccountService.Login.Email;)
            }

            public string Password
            {
                get { return _password; }
                set
                {
                    SetValue(ref _password, value);
                }
            }
           

            // make email in login and logout 
            public Command LoginUserCommand { get; }
            private async void Login()
            {
                //IsBusy = true;
                await App.Current.MainPage.Navigation.PushPopupAsync(new LoadingPopup());
                var validationRes = _validator.Validate<LoginPageViewModel>(this);
                if (validationRes)
                {
                    var serviceResult = await AccountService.Login(this);
                    if (serviceResult == ResponseResults.LoginUserResult.Failed.ToString())
                        await Application.Current.MainPage.DisplayAlert("عفوا", "البريد الإلكتروني او كلمة السر غير صحيحة", "اغلق");
                    else if (serviceResult == ResponseResults.LoginUserResult.InActive.ToString())
                        await Application.Current.MainPage.DisplayAlert("عفوا", "هذا البريد غير مفعل الان برجـاء مراجـعة الادمن", "اغلق");
                    else if (serviceResult == ResponseResults.LoginUserResult.Bokcked.ToString())
                        await Application.Current.MainPage.DisplayAlert("عفوا", "تم تعطيل هذا الحساب لعدم التزامه بحضور الحجوزات", "اغلق");
                    else
                    {
                        //UserDAL dal = new UserDAL();
                        //dal.DeleteAll();
                        //var loginResult = JsonConvert.DeserializeObject<LoginResultViewModel>(serviceResult);
                        //dal.AddUser(loginResult);

                        if (ReturnToReservePlayground)
                            await Application.Current.MainPage.Navigation.PopModalAsync();
                        
                    }
                }
                await App.Current.MainPage.Navigation.PopPopupAsync(true);
                //IsBusy = false;
            }

            //private void MoveToRegisterPage()
            //{
            //    Application.Current.MainPage = new RegisterPage();
            //}
            //public void ForgetPasswordPage()
            //{
            //    Application.Current.MainPage = new ForgetPassword();
            //}
            //private async void ForgetPassword()
            //{
            //    await Application.Current.MainPage.Navigation.PushAsync(new ForgetPassword(this));
            //}

            //public async void sendMail()
            //{
            //    var result = await AccountService.ForgetPassword(Email);
            //    if (result == string.Empty)
            //        await Application.Current.MainPage.DisplayAlert("عفوا", "لم يتم حفظ التعديلات", "اغلق");
            //    else
            //    {
            //        // write code send mail after return to login page
            //        await Application.Current.MainPage.DisplayAlert("تعديل كلمة المرور", "تم ارسال الى البريد الالكترونى", "تم");
            //         await Application.Current.MainPage.Navigation.PopAsync();
            //    }
            //}
            private async void MoveToPlaygroundsPage()
            {
                await App.Current.MainPage.Navigation.PushPopupAsync(new LoadingPopup());
                Application.Current.MainPage = new NavigationPage(new MainPage());
                await App.Current.MainPage.Navigation.PopAllPopupAsync(true);
            }

            public void ConfigureValidationRules()
            {
                _validator.AddRule("Email", RegexResource.Email);
                _validator.AddRule("Password", RegexResource.Required);
            }

        }
    }
