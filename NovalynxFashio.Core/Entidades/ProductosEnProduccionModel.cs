using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovalynxFashion.Core.Enums;


namespace NovalynxFashion.Core.Entidades
{
    public class ProductosEnProduccionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre del Producto a Producir")]
        public string NombreProducto { get; set; }

        // Lista de productos suministradores (ingredientes) necesarios para la producción
        public List<ProductoSuministradorModel> Ingredientes { get; set; } = new List<ProductoSuministradorModel>();
        public EstadoProductoEnProduccionEnum EstadoProducto { get; set; }
        public decimal Coste {  get; set; }
        public int Cantidad { get; set; }

        public TipoDeProductoEnVentasEnum TipoDeProductoEnVentas { get; set; }
        public GeneroEnum Sexo { get; set; }
        public TallaEnum Talla { get; set; }
        public string Descripcion { get; set; }
        public PersonasEnum PersonasEnum { get; set; }
        public SubtipoRopaEnum SubtipoRopa {  get; set; }
        public MonedaPreferenciaEnum? MonedaPreferida { get; set; }
        public string ImagePath { get; set; }
    }
}
