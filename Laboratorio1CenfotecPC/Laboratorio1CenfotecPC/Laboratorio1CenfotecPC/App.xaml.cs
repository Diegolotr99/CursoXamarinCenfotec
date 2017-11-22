using Laboratorio1CenfotecPC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Laboratorio1CenfotecPC
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            NavigationPage navigation = new NavigationPage(new HomePage());

            App.Current.MainPage = new MasterDetailPage
            {
                Master = new HomeMenu(),
                Detail = navigation
            };

            //MainPage = new HomePage();
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
