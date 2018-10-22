using ColorSelectorSamuelBering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSelectorSamuelBering.Models
{
    public interface IColorSelectorService
    {
        void SaveColors(List<CustomColor> colors);
        List<CustomColor> LoadColors();
    }
}
