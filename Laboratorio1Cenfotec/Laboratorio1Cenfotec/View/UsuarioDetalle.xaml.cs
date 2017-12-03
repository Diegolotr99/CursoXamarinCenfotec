using System;
using System.Collections.Generic;
using Laboratorio1Cenfotec.ViewModel;

using Xamarin.Forms;

namespace Laboratorio1Cenfotec.View
{
    public partial class UsuarioDetalle : ContentPage
    {
        public UsuarioDetalle()
        {
            InitializeComponent();

            BindingContext = PersonaViewModel.GetInstance();
        }
    }
}
