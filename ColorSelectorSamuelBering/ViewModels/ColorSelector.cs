using ColorSelectorSamuelBering.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ColorSelectorSamuelBering.ViewModels
{
    public class ColorSelector : ObservableObject
    {
        private CustomColor _selectedColor;

        public CustomColor CurrentColor { get; set; }

        public CustomColor SelectedColor
        {
            get{
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

        public ColorSelector()
        {
            CurrentColor = new CustomColor();
            CurrentColor.R = 255;
            ColorList = new ObservableCollection<CustomColor>();
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
                return new DelegateCommand(RemoveColor);
            }
        }

        private void RemoveColor(object parameter)
        {

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
            CurrentColor.R=selectedColor.R;
            CurrentColor.G = selectedColor.G;
            CurrentColor.B = selectedColor.B;
            _selectedColor = selectedColor;
        }

        private void AddColor(object parameter)
        {
            ColorList.Add(new CustomColor(parameter as CustomColor));
        }
    }
}
