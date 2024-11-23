using NovalynxFashion.Core.Enums;


namespace NovalynxFashion.Core.Entidades
{
    public class ProductosParaLaVentaModel
    {
        public int Id { get; set; }
        public int ProductosEnProduccionModelId { get; set; }
        public ProductosEnProduccionModel ProductosTerminados { get; set; }
        public DateTime FechaDeCreacion { get; set; }
    }
}
