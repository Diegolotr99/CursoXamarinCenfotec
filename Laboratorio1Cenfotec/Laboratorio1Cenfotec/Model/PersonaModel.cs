using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;  

namespace Laboratorio1Cenfotec.Model
{
    public class PersonaModel
    {
        public int Id { get; set; }

        public string FotoPath { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Sexo { get; set; }

        public string Observaciones { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
            }
            private set{}

        }

        public ObservableCollection<VentasModel> lstVentas { get; set; }

        public PersonaModel()
        {
        }

        public static async Task<ObservableCollection<PersonaModel>> ObtenerPersonas()
        {

            ObservableCollection<PersonaModel> lstPersonas = new ObservableCollection<PersonaModel>();

           

            lstPersonas.Add(new PersonaModel { Id = 1, Nombre = "Carlos" });
            lstPersonas.Add(new PersonaModel { Id = 2, Nombre = "Yendry" });
            lstPersonas.Add(new PersonaModel { Id = 3, Nombre = "Natasha" });

            Thread.Sleep(4000);


            return lstPersonas;

        }

    }
}
