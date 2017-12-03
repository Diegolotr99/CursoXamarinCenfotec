using System;
using System.Collections.Generic;
using Laboratorio3.ViewModel;
using Xamarin.Forms;

namespace Laboratorio3.View
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            BindingContext = new TabbedPageViewModel();
        }
    }
}
