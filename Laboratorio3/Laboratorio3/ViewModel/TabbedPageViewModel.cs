using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Laboratorio3.Model;

namespace Laboratorio3.ViewModel
{
    public class TabbedPageViewModel : INotifyPropertyChanged
    {
        #region Intances

        private ObservableCollection<CDModel> _lstXmlModel { get; set; }

        public ObservableCollection<CDModel> lstXmlModel
        {
            get
            {
                return _lstXmlModel;
            }
            set
            {
                _lstXmlModel = value;
                OnPropertyChanged("lstXmlModel");
            }
        }




        #endregion

        public TabbedPageViewModel()
        {
            InitClass();

        }


        #region Methods

        private async void InitClass()
        {

            lstXmlModel = await XmlModel.LoadXMLData();
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
