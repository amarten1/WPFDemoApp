using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemoApp.ViewModels;

namespace WPFDemoApp.Models
{
    public class ViewModelContainer
    {
        #region main window view model
        private static MainWindowViewModel mainWindowViewModel;
        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                if (mainWindowViewModel == null)
                {
                    mainWindowViewModel = new MainWindowViewModel();
                }
                return mainWindowViewModel;
            }
        }
        #endregion
    }
}
