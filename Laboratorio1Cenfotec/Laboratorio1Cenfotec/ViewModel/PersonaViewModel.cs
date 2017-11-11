using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Laboratorio1Cenfotec.Model;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Laboratorio1Cenfotec.ViewModel
{
    public class PersonaViewModel : INotifyPropertyChanged
    {
        #region Instances

        private List<PersonaModel> lstOriginalPersonas = new List<PersonaModel>();

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

        private string _TextoBuscar = string.Empty;

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }
            set
            {
                _TextoBuscar = value;
                OnPropertyChanged("TextoBuscar");
                FiltrarPersona(_TextoBuscar);
            }
        }

        private string _NuevaPersona = string.Empty;

        public string NuevaPersona
        {
            get
            {
                return _NuevaPersona;
            }
            set
            {
                _NuevaPersona = value;
                OnPropertyChanged("NuevaPersona");
            }
        }


        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }

        #endregion


        public PersonaViewModel()
        {

            InitClass();
            InitCommand();
        }

        #region Methods

        private void AgregarPersona()
        {
            lstPersonas.Add(new PersonaModel { Nombre = NuevaPersona });
            lstOriginalPersonas.Add(new PersonaModel{ Nombre = NuevaPersona});

            NuevaPersona = string.Empty;
        }

        private void FiltrarPersona(string textoBuscar)
        {
            lstPersonas.Clear();
            lstOriginalPersonas.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x => lstPersonas.Add(x));

        }

        private void BorrarPersona(int id)
        {

            lstOriginalPersonas.RemoveAll(x=> x.Id == id);


        }

        private async Task InitClass()
        {
            
            lstPersonas = await PersonaModel.ObtenerPersonas();

            lstOriginalPersonas = lstPersonas.ToList();
        }

        private void InitCommand()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command<int>(BorrarPersona);
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
