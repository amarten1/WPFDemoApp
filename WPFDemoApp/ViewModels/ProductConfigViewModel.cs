using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemoApp.Models;

namespace WPFDemoApp.ViewModels
{
    public class ProductConfigViewModel : ObservableObject
    {
        #region model number
        private string _modelNumber = "DEMO-XR4";
        public string ModelNumber
        {
            get => _modelNumber;
            set
            {
                _modelNumber = value;
                RaisePropertyChangedEvent("ModelNumber");
            }
        }
        #endregion
    }
}
