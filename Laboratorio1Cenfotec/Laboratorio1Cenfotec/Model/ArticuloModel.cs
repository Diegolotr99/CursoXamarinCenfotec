using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Laboratorio1Cenfotec.Model
{
    public class ArticuloModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string NombreArticulo { get; set; }

        public double Precio { get; set; }

        private bool _isChecked { get; set; }

        public bool isChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                OnPropertyChanged("isChecked");

            }

        }


        public ArticuloModel()
        {
        }

        #region Methods

        public static ObservableCollection<ArticuloModel> ObtenerTodosArticulos()
        {
            ObservableCollection<ArticuloModel> lstArticulos = new ObservableCollection<ArticuloModel>();

            lstArticulos.Add(new ArticuloModel { Id = 1, NombreArticulo = "Laptop", Precio=100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 2, NombreArticulo = "Servidor", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 3, NombreArticulo = "Mouse", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 4, NombreArticulo = "Convertidor", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 5, NombreArticulo = "Pantalla", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 6, NombreArticulo = "Monitor", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 7, NombreArticulo = "Baterias", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 8, NombreArticulo = "UPS", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 9, NombreArticulo = "Teclado", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 10, NombreArticulo = "Fibra Optica", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 11, NombreArticulo = "Cargador", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 12, NombreArticulo = "Laptop", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 13, NombreArticulo = "Laptop", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 14, NombreArticulo = "Laptop", Precio = 100000.00, });
            lstArticulos.Add(new ArticuloModel { Id = 15, NombreArticulo = "Laptop", Precio = 100000.00, });


            return lstArticulos;

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
