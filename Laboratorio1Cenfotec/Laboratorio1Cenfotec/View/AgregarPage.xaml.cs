using System;
using System.Collections.Generic;
using Laboratorio1Cenfotec.ViewModel;
using Xamarin.Forms;

namespace Laboratorio1Cenfotec.View
{
    public partial class AgregarPage : ContentPage
    {
        public AgregarPage()
        {
            InitializeComponent();

            BindingContext = new PersonaViewModel();
        }
    }
}
