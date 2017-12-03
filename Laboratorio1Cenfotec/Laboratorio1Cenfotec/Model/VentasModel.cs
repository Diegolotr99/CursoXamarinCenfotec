using System;
using System.Collections.ObjectModel;

namespace Laboratorio1Cenfotec.Model
{
    public class VentasModel
    {
         
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public double Monto { get; set; }

        public int TipoVenta { get; set; }

        public ObservableCollection<ArticuloModel> ArticuloId { get; set; }


        public VentasModel()
        {
        }


    }
}
