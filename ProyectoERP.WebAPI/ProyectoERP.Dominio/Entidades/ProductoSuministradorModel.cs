namespace ProyectoERP.Dominio.Entidades
{
    public class ProductoSuministradorModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int SuministradorId { get; set; }
        public SuministradorModel Suministrador {  get; set; }
        public decimal Precio { get; set; }
        public bool ConIVA { get; set; }
        public decimal? IVA { get; set; }
        public decimal PrecioTotal { get
            {
                if (ConIVA == false)
                {
                     return Precio;
                } else
                {
                    return (decimal)(Precio * IVA);
                } 
                
            } 
        }
       
    }
}
