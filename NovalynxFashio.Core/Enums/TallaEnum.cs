using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Enums
{
    public enum TallaEnum
    {

        XXSmall = 0, 
        XSmall = 1, 
        Small = 2, 
        Medium = 3, 
        Large = 4, 
        XLarge = 5, 
        XXLarge = 6, 
        XXXLarge = 7,
        [Display(Name = "Toda la talla")]
        TodaLaTalla = 8, 
        Personalizado = 9
    }
}
