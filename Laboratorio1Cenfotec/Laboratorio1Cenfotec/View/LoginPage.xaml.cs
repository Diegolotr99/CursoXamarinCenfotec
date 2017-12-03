using System;
using System.Collections.Generic;
using Laboratorio1Cenfotec.ViewModel;
using Xamarin.Forms;

namespace Laboratorio1Cenfotec.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
