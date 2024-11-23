using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovalynxFashion.Core.Enums;

namespace NovalynxFashion.Core.Entidades
{
    public class ProductoSuministradorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre del Producto")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Moneda Preferida")]
        public MonedaPreferenciaEnum MonedaPreferida {  get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Coste del producto")]
        public decimal CosteProducto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Cantidad")]
        public int CantidadProducto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Unidad")]
        public UnidadesEnum UnidadProducto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre del proveedor")]
        public int SuministradorId { get; set; }
        public SuministradorModel Suministrador { get; set; }
        public List<ProductosEnProduccionModel> ProductosEnVentas { get; set; } = new List<ProductosEnProduccionModel>();   
        public string ImagePath { get; set; }
    }
}
