using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Enums
{
    public enum TipoDeProductoEnVentasEnum
    {
       [Display(Name = "Ropa Casual")]
       RopaCasual = 0,
       [Display(Name = "Ropa Formal")]
       RopaFormal = 1,
       [Display(Name = "Ropa de Oficina")]
       RopaDeOficina = 2,
       [Display(Name = "Ropa Deportiva")]
       RopaDeportiva = 3, 
       [Display(Name = "Ropa de Invierno")]
       RopaDeInvierno = 4,
       [Display(Name = "Ropa de Verano")]
       RopaDeVerano = 5, 
       [Display(Name = "Ropa Interior")]
       RopaInterior = 6,
       [Display(Name = "Ropa Traducional")]
       RopaTradicional = 7, 
       [Display(Name = "Ropa Accesorios y Complementarios")]
       AccesoriosComplementarios = 8, 
       Calzados = 9
    }
}
