using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemoApp.Pages
{
    /// <summary>
    /// Interaction logic for ProductConfig.xaml
    /// </summary>
    public partial class ProductConfig : Page
    {
        public ProductConfig()
        {
            InitializeComponent();

            DataContext = new ViewModels.ProductConfigViewModel();
        }

        private void CheckIsNumeric(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!(int.TryParse(e.Text, out int result) || e.Text == "."))
            {
                e.Handled = true;
            }

            if (e.Text == "." && tb.Text.IndexOf(".") > -1)
                e.Handled = true;
        }
    }
}
