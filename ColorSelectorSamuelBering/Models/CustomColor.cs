using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSelectorSamuelBering.Models
{
    public class CustomColor : INotifyPropertyChanged
    {
        private byte r;
        private byte g;
        private byte b;

        public CustomColor()
        {

        }

        public CustomColor(CustomColor c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }

        public byte R
        {
            get { return this.r; }
            set
            {
                if (this.r != value)
                {
                    this.r = value;
                    this.NotifyPropertyChanged("R");
                }
            }
        }

        public byte G
        {
            get { return this.g; }
            set
            {
                if (this.g != value)
                {
                    this.g = value;
                    this.NotifyPropertyChanged("G");
                }
            }
        }

        public byte B
        {
            get { return this.b; }
            set
            {
                if (this.b != value)
                {
                    this.b = value;
                    this.NotifyPropertyChanged("B");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

}
