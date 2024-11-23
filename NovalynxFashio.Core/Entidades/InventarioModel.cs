using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Entidades
{
    public class InventarioModel
    {
        public int Id { get; set; }
        public int? OrdenCarritoId { get; set; }
        public OrdenesEnCarritoModel OrdenCarrito { get; set; }
        public int StockActual { get; set; }
        public int ProductoSuministradorId { get; set; }
        public ProductoSuministradorModel ProductoSuministrador { get; set; }
    }
}
