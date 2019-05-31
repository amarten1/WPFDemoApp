using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDemoApp.Models;

namespace WPFDemoApp.ViewModels
{
    public class PaletteSelectorViewModel : ObservableObject
    {
        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }

        public ICommand ToggleBaseCommand { get; } = new AnotherCommandImplementation(o => ApplyBase((bool)o));

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public bool LightDark
        {
            get { return Properties.Settings.Default.LightDark; }
            set
            {
                Properties.Settings.Default.LightDark = value;
                Properties.Settings.Default.Save();
            }
        }

        private IEnumerable<Swatch> _swatches;
        public IEnumerable<Swatch> Swatches
        {
            get { return _swatches; }
            set
            {
                _swatches = value;
                RaisePropertyChangedEvent("Swatches");
            }
        }

        public ICommand ApplyPrimaryCommand { get; } = new AnotherCommandImplementation(o => ApplyPrimary((Swatch)o));

        private static void ApplyPrimary(Swatch swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
            Properties.Settings.Default.PrimaryColor = swatch.Name;
            Properties.Settings.Default.Save();
        }

        public ICommand ApplyAccentCommand { get; } = new AnotherCommandImplementation(o => ApplyAccent((Swatch)o));

        private static void ApplyAccent(Swatch swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
            Properties.Settings.Default.AccentColor = swatch.Name;
            Properties.Settings.Default.Save();
        }

        //back command
        public ICommand BackCommand
        {
            get => new DelegateCommand(GoBack);
        }

        public void GoBack()
        {
            ViewModelContainer.MainWindowViewModel.CloseSettings();
        }
    }
}
