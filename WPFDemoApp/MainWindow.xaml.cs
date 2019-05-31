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
using WPFDemoApp.Models;

namespace WPFDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = Models.ViewModelContainer.MainWindowViewModel;
        }

        private void PageSelect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;

            ViewModelContainer.MainWindowViewModel.PageSelect(item.Name);

            drawerHost.IsLeftDrawerOpen = false;
        }

        private void Settings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;

            ViewModelContainer.MainWindowViewModel.OpenSettings();
        }
    }
}
