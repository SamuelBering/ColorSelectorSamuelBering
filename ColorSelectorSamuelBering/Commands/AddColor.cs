using ColorSelectorSamuelBering.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ColorSelectorSamuelBering.Commands
{
    class AddColor : ICommand
    {
        #region ICommand Members

        private ObservableCollection<CustomColor> _colorList;

        public AddColor(ObservableCollection<CustomColor> colorList)
        {
            _colorList = colorList;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _colorList.Add(new CustomColor(parameter as CustomColor));
            //Your Code
        }
        #endregion
    }
}
