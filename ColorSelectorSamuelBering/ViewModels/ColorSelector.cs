using ColorSelectorSamuelBering.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ColorSelectorSamuelBering.ViewModels
{
    public class ColorSelector : ObservableObject
    {
        public CustomColor CurrentColor { get; set; }
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

        private void AddColor(object parameter)
        {
            ColorList.Add(new CustomColor(parameter as CustomColor));
        }
    }
}
