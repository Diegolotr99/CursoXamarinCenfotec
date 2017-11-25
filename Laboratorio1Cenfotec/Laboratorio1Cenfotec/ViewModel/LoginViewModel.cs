using System;
using System.ComponentModel;
using System.Windows.Input;
using Laboratorio1Cenfotec.Model;
using Laboratorio1Cenfotec.View;
using Xamarin.Forms;

namespace Laboratorio1Cenfotec.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Instances

        public ICommand LoginCommand { get; set; }

        private string _User { get; set; }

        public string User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }

        }

        private string _Password { get; set; }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }

        }

        #endregion
        public LoginViewModel()
        {
            InitCommands();
        }

        #region Methods
        private void Login()
        {

            if(LoginModel.Auntenticar(User,Password))
            {
                NavigationPage navigation = new NavigationPage(new HomePage());

                App.Current.MainPage = new MasterDetailPage
                {
                    Master = new HomeMenu(),
                    Detail = navigation
                };
            }
            else
            {
                 App.Current.MainPage.DisplayAlert("Mensaje", "Credenciales Invalidas", "OK");
            }

           
        }

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
        }

        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
