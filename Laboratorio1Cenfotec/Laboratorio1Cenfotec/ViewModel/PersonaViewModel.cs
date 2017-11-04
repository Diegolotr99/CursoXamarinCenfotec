using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Laboratorio1Cenfotec.Model;
using Xamarin.Forms;

namespace Laboratorio1Cenfotec.ViewModel
{
    public class PersonaViewModel : INotifyPropertyChanged
    {
        #region Instances
        private ObservableCollection<PersonaModel> _lstPersonas = new ObservableCollection<PersonaModel>();
        public ObservableCollection<PersonaModel> lstPersonas
        {
            get
            {
                return _lstPersonas;
            }
            set
            {
                _lstPersonas = value;
                OnPropertyChanged("lstProducts");
            }
        }

        public ICommand AgregarPersonaCommand { get; set; }

        #endregion


        public PersonaViewModel()
        {

            InitCommand();

            lstPersonas.Add(new PersonaModel { Nombre = "Carlos" });
            lstPersonas.Add(new PersonaModel { Nombre = "Yendry" });
            lstPersonas.Add(new PersonaModel { Nombre = "Natasha" });
        }

        #region Methods

        private void AgregarPersona()
        {
            lstPersonas.Add(new PersonaModel { Nombre = "Sofia" });
        }

        private void InitCommand()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
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
