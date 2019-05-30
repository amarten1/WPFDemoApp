using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemoApp.Models;

namespace WPFDemoApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region main frame source
        private Uri _mainFrameSource = new Uri("../Pages/WelcomePage.xaml", UriKind.Relative);
        public Uri MainFrameSource
        {
            get { return _mainFrameSource; }
            set
            {
                if (_mainFrameSource != value)
                {
                    _mainFrameSource = value;
                    RaisePropertyChangedEvent("MainFrameSource");
                }
            }
        }
        #endregion
    }
}
