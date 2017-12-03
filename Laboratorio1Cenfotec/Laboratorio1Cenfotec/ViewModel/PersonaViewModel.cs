using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Laboratorio1Cenfotec.Model;
using Xamarin.Forms;
using System.Threading.Tasks;
using Laboratorio1Cenfotec.View;

namespace Laboratorio1Cenfotec.ViewModel
{
    public class PersonaViewModel : INotifyPropertyChanged
    {
        #region Singleton
        private static PersonaViewModel instance = null;

        private PersonaViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static PersonaViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PersonaViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion

        #region Instances

        //Instancias de Venta


        private string _DescripcionNuevaVenta { get; set; }

        public string DescripcionNuevaVenta
        {
            get
            {
                return _DescripcionNuevaVenta;
            }
            set
            {
                _DescripcionNuevaVenta = value;
                OnPropertyChanged("DescripcionNuevaVenta");

            }
        }

        private string _FechaNuevaVenta { get; set; }

        public string FechaNuevaVenta
        {
            get
            {
                return _FechaNuevaVenta;
            }
            set
            {
                _FechaNuevaVenta = value;
                OnPropertyChanged("FechaNuevaVenta");

            }
        }

        private string _TipoVenta { get; set; }

        public string TipoVenta
        {
            get
            {
                return _TipoVenta;
            }
            set
            {
                _TipoVenta = value;
                OnPropertyChanged("TipoVenta");

            }
        }


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
                OnPropertyChanged("lstPersonas");
            }
        }

        private ObservableCollection<ArticuloModel> _lstArticulos = new ObservableCollection<ArticuloModel>();

        public ObservableCollection<ArticuloModel> lstArticulos
        {
            get
            {
                return _lstArticulos;
            }
            set
            {
                _lstArticulos = value;
                OnPropertyChanged("lstArticulos");
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

        private PersonaModel _PersonaActual { get; set; }

        public PersonaModel PersonaActual
        {
            get
            {
                return _PersonaActual;
            }
            set
            {
                _PersonaActual = value;
                OnPropertyChanged("PersonaActual");
            }
        }


        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }
        public ICommand VerPersonaCommand { get; set; }
        public ICommand EnterNuevaVentaCommand { get; set; }
        public ICommand CrearVentaCommand { get; set; }
        public ICommand ArticuloSeleccionadoCommand { get; set; }

        #endregion

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

        private void VerPersona(int id)
        {
            PersonaActual =  lstOriginalPersonas.Where(x=> x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new UsuarioDetalle());

        }

        private void EnterNuevaVenta()
        {

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new FormularioNuevaVenta());
        }

        private void CrearVenta()
        {
            

        }

        private async Task InitClass()
        {
            lstArticulos =  ArticuloModel.ObtenerTodosArticulos();
             
            lstPersonas = await PersonaModel.ObtenerPersonas();

            lstOriginalPersonas = lstPersonas.ToList();
        }

        private void ArticuloSeleccionado(int id)
        {
            try
            {
                lstArticulos.Where(x=> x.Id == id).FirstOrDefault().isChecked = true;
            }
            catch (Exception ex)
            {

            }

        }

        private void InitCommands()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command<int>(BorrarPersona);
            VerPersonaCommand = new Command<int>(VerPersona);
            EnterNuevaVentaCommand = new Command(EnterNuevaVenta);
            CrearVentaCommand = new Command(CrearVenta);
            ArticuloSeleccionadoCommand = new Command<int>(ArticuloSeleccionado);
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
