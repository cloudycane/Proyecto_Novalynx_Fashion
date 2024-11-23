using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Enums
{
    public enum GeneroEnum
    {
        Hombre = 0,
        Mujeres = 1, 
        Unisex = 2, 
        Personalizado = 3,
        [Display(Name = "Todas las personas")]
        TodasLasPersonas = 4
    
    }
}
