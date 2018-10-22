using ColorSelectorSamuelBering.Commands;
using ColorSelectorSamuelBering.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ColorSelectorSamuelBering.ViewModels
{
    public class ColorSelector : ObservableObject
    {
        private CustomColor _selectedColor;

        private IColorSelectorService _colorSelectorService;

        public CustomColor CurrentColor { get; set; }

        public CustomColor SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    NotifyPropertyChanged("SelectedColor");
                }
            }
        }
        public ObservableCollection<CustomColor> ColorList { get; set; }

        public ColorSelector(IColorSelectorService colorSelectorService)
        {
            _colorSelectorService = colorSelectorService;
        }

        public ColorSelector() : this(new ColorSelectorService())
        {
            CurrentColor = new CustomColor();
            ColorList = new ObservableCollection<CustomColor>();
        }

        public ICommand SaveColorsCommand
        {
            get
            {
                return new DelegateCommand(SaveColors, parameter => ColorList.Count > 0 ? true : false);
            }
        }

        public ICommand LoadColorsCommand
        {
            get
            {
                return new DelegateCommand(LoadColors);
            }
        }

        public ICommand AddColorCommand
        {
            get
            {
                return new DelegateCommand(AddColor);
            }
        }

        public ICommand RemoveColorCommand
        {
            get
            {
                return new DelegateCommand(RemoveColor, parameter => SelectedColor != null ? true : false);
            }
        }

        private void RemoveColor(object parameter)
        {
            ColorList.Remove(parameter as CustomColor);
        }

        public ICommand SelectedColorChangedCommand
        {
            get
            {
                return new DelegateCommand(SelectedColorChanged);
            }
        }

        private void SelectedColorChanged(object parameter)
        {
            var selectedColor = parameter as CustomColor;
            if (selectedColor == null)
            {
                SelectedColor = null;
                return;
            }

            CurrentColor.R = selectedColor.R;
            CurrentColor.G = selectedColor.G;
            CurrentColor.B = selectedColor.B;
            SelectedColor = selectedColor;
        }

        private void SaveColors(object parameter)
        {
            var colors = parameter as ObservableCollection<CustomColor>;
            _colorSelectorService.SaveColors(colors.ToList());
        }

        private void LoadColors(object parameter)
        {
            var colorList = parameter as ObservableCollection<CustomColor>;
            var colors = _colorSelectorService.LoadColors();

            colorList.Clear();
            foreach(var color in colors)
            {
                colorList.Add(color);
            }

            SelectedColor = null;
        }

        private void AddColor(object parameter)
        {
            ColorList.Add(new CustomColor(parameter as CustomColor));
        }
    }
}
