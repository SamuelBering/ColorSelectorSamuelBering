using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSelectorSamuelBering.DAL
{
    public class ColorSelectorDBContext: DbContext
    {
       public DbSet<Color> Colors { get; set; }
    }

}
