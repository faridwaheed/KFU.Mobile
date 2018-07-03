using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KFU.Mobile.Views;
using Xamarin.Forms;

namespace KFU.Mobile
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new SchoolSchedulePage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
