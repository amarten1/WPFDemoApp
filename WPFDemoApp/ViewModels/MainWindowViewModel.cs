﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemoApp.Models;

namespace WPFDemoApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private string previousPage = "Welcome";
        private string currentPage = "Welcome";

        private readonly ProductPages welcomePage = new ProductPages() { Name = "Welcome", Uri = new Uri("../Pages/WelcomePage.xaml", UriKind.Relative), Title = "WELCOME" };
        private readonly ProductPages productConfig = new ProductPages() { Name = "ProductConfig", Uri = new Uri("../Pages/ProductConfig.xaml", UriKind.Relative), Title = "PRODUCT DEMO" };

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

        #region page title
        private string _pageTitle = "WELCOME";
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                if (_pageTitle != value)
                {
                    _pageTitle = value;
                    RaisePropertyChangedEvent("PageTitle");
                }
            }
        }
        #endregion

        //page select function
        #region page select
        public void PageSelect(string name)
        {
            previousPage = currentPage;
            currentPage = name;

            List<ProductPages> pages = new List<ProductPages>
            {
                welcomePage,
                productConfig
            };

            var selectedPage = pages.First(s => s.Name == name);

            MainFrameSource = selectedPage.Uri;
            PageTitle = selectedPage.Title;
        }
        #endregion

        //settings dialog functions
        #region settings dialog open
        private bool _settingsDialogOpen = false;
        public bool SettingsDialogOpen
        {
            get => _settingsDialogOpen;
            set
            {
                if (_settingsDialogOpen != value)
                {
                    _settingsDialogOpen = value;
                    RaisePropertyChangedEvent("SettingsDialogOpen");
                }
            }
        }
        #endregion

        #region settings dialog content
        private object _settingsDialogContent;
        public object SettingsDialogContent
        {
            get => _settingsDialogContent;
            set
            {
                if (_settingsDialogContent != value)
                {
                    _settingsDialogContent = value;
                    RaisePropertyChangedEvent("SettingsDialogContent");
                }
            }
        }
        #endregion

        #region open and close settings functions
        public void OpenSettings()
        {
            SettingsDialogContent = new Pages.PaletteSelector()
            {
                Width = 800,
                Height = 600
            };
            SettingsDialogOpen = true;
        }
        public void CloseSettings()
        {
            SettingsDialogOpen = false;
        }
        #endregion

        class ProductPages
        {
            public string Name { get; set; }
            public Uri Uri { get; set; }
            public string Title { get; set; }
        }
    }
}
