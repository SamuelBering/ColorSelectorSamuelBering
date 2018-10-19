using ColorSelectorSamuelBering.Commands;
using ColorSelectorSamuelBering.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

/*
 
 Datamember
 Color currentColor
 List<Colors> colorList
     */

namespace ColorSelectorSamuelBering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CustomColor currentColor { get; set; }
        public string test { get; set; } = "Hej";
        public ObservableCollection<CustomColor> colorList { get; set; }

        private ICommand addColorCommand;
        public ICommand AddColorCommand
        {
            get
            {
                if (addColorCommand == null)
                    addColorCommand = new AddColor(colorList);
                return addColorCommand;
            }
            set
            {
                addColorCommand = value;
            }
        }

        public MainWindow()
        {
            currentColor = new CustomColor();
            currentColor.R = 255;
            colorList = new ObservableCollection<CustomColor>();
            InitializeComponent();
            this.DataContext = this;
        }
    }

   
}
