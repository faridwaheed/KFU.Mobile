using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KFU.Mobile.Helpers
{
    public class NavigationHelper
    {
        public static void NavigateAsync(Page page)
        {
            App.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}
