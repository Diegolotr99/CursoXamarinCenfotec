using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;  

namespace Laboratorio1Cenfotec.Model
{
    public class PersonaModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public PersonaModel()
        {
        }

        public static async Task<ObservableCollection<PersonaModel>> ObtenerPersonas()
        {

            ObservableCollection<PersonaModel> lstPersonas = new ObservableCollection<PersonaModel>();

           

            lstPersonas.Add(new PersonaModel { Id = 1, Nombre = "Carlos" });
            lstPersonas.Add(new PersonaModel { Id = 2, Nombre = "Yendry" });
            lstPersonas.Add(new PersonaModel { Id = 3, Nombre = "Natasha" });

            Thread.Sleep(6000);


            return lstPersonas;

        }

    }
}
