using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Enums
{
    public enum RoleEnum
    {
        Empleado = 0,
        [Display(Name= "Recurso Humano RRHH")]
        RecursoHumano = 1,
        Suministrador = 2, 
        Financiero = 3, 
        Ventas = 4, 
        Cliente = 5
    }
}
