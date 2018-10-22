using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorSelectorSamuelBering.DAL;
using ColorSelectorSamuelBering.ViewModels;

namespace ColorSelectorSamuelBering.Models
{
    public class ColorSelectorService : IColorSelectorService
    {
        public List<CustomColor> LoadColors()
        {
            using (ColorSelectorDBContext dbContext = new ColorSelectorDBContext())
            {
                var colors = dbContext.Colors.ToList();
                var result = ConvertColors(colors);
                return result;               
            }
        }

        public void SaveColors(List<CustomColor> colors)
        {
            using (ColorSelectorDBContext dbContext = new ColorSelectorDBContext())
            {
                var colorsToSave = ConvertColors(colors);
                dbContext.Colors.AddRange(colorsToSave);
                dbContext.SaveChanges();
            }
        }

        private List<Color> ConvertColors(List<CustomColor> colors)
        {
            var result = new List<Color>();
            
            foreach(var color in colors)
            {
                result.Add(new Color
                {
                    R = color.R,
                    G = color.G,
                    B=color.B                
                });
            }
            return result;
        }

        private List<CustomColor> ConvertColors(List<Color> colors)
        {
            var result = new List<CustomColor>();

            foreach (var color in colors)
            {
                result.Add(new CustomColor
                {
                    R = color.R,
                    G = color.G,
                    B = color.B
                });
            }
            return result;
        }
    }
}
