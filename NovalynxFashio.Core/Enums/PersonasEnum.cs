using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Enums
{
    public enum PersonasEnum
    {
        Bebes = 0, 
        Infantiles = 1, 
        Jovenes = 2, 
        Adultos = 3,
        [Display(Name = "Todas las personas")]
        TodasLasEdades = 4
    }
}
