using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region model
        public ObservableCollection<string> ModelList { get; } = new ObservableCollection<string> { "X10", "X20", "X30" };

        private string _model = "X10";
        public string Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChangedEvent("Model");
                    UpdateAll();
                }
            }
        }
        #endregion

        #region rotors
        public ObservableCollection<string> RotorList { get; } = new ObservableCollection<string> { "3", "4", "5" };

        private string _rotors = "4";
        public string Rotors
        {
            get { return _rotors; }
            set
            {
                if (_rotors != value)
                {
                    _rotors = value;
                    RaisePropertyChangedEvent("Rotor");
                    UpdateAll();
                }
            }
        }
        #endregion

        #region gps
        private bool _gps = true;
        public bool GPS
        {
            get { return _gps; }
            set
            {
                if (_gps != value)
                {
                    _gps = value;
                    RaisePropertyChangedEvent("GPS");
                    UpdateAll();
                }
            }
        }
        #endregion

        #region paint
        public ObservableCollection<string> PaintList { get; } = new ObservableCollection<string> { "Black", "Red", "Yellow", "White" };

        private string _paint = "Black";
        public string Paint
        {
            get { return _paint; }
            set
            {
                if (_paint != value)
                {
                    _paint = value;
                    RaisePropertyChangedEvent("Paint");
                    UpdateAll();
                }
            }
        }
        #endregion

        #region quote text field
        private string _quoteText;
        public string QuoteText
        {
            get { return _quoteText; }
            set
            {
                if (_quoteText != value)
                {
                    _quoteText = value;
                    RaisePropertyChangedEvent("QuoteText");
                }
            }
        }
        #endregion

        #region pricing field
        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChangedEvent("Price");
                }
            }
        }
        #endregion

        //update all function
        #region update all
        public void UpdateAll()
        {
            UpdateModelNum();
            UpdateQuoteText();
            UpdatePrice();
        }
        #endregion

        //update model number
        #region update model number
        public void UpdateModelNum()
        {
            ModelNumber = "DEMO-" + Model;
        }
        #endregion

        //update quote text
        #region quote text
        public void UpdateQuoteText()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Demo configurator and quote builder.");
            s.AppendLine();
            s.AppendLine();
            s.Append("Drone Demo model build.");
            s.AppendLine();
            s.AppendLine();
            s.Append("Model:  " + Model);
            s.AppendLine();
            s.AppendLine();
            s.Append("Number of Rotors:  " + Rotors);
            s.AppendLine();
            s.AppendLine();
            s.Append("GPS Navigation:  " + GPS);
            s.AppendLine();
            s.AppendLine();
            s.Append("Paint Color:  " + Paint);

            QuoteText = s.ToString();
        }
        #endregion

        #region update price
        public void UpdatePrice()
        {
            decimal p = 0;

            if (Model == "X10")
                p += 100;
            else if (Model == "X20")
                p += 150;
            else
                p += 200;

            if (Rotors == "3")
                p -= 20;

            if (Rotors == "5")
                p += 20;

            if (GPS)
                p += 60;

            Price = "$" + p;
        }
        #endregion
    }
}
