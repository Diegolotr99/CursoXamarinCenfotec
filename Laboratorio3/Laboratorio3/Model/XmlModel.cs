using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorio3.Model
{
    public class XmlModel
    {

    

        public XmlModel()
        {
        }

        public static async Task<ObservableCollection<CDModel>> LoadXMLData()
        {
            try
            {
                ObservableCollection<CDModel> lstXml = new ObservableCollection<CDModel>();

                await Task.Factory.StartNew(delegate {

                    XDocument doc = XDocument.Load("catalog.xml");

                    var result = doc.Descendants("CD");

                    foreach (var item in result)
                    {
                        var a = item.Descendants("TITLE").FirstOrDefault();

                        lstXml.Add(new CDModel { Title = a.Value});

                    }


                });


                return lstXml;
            }

            catch (Exception ex)
            {
                return null;
            }

        }


    }

    public class CDModel
    {

        public string Title { get; set; }
        public string Artist { get; set; }
        public string Country { get; set; }
        public string Price { get; set; }
        public string Year { get; set; }

    }
}
