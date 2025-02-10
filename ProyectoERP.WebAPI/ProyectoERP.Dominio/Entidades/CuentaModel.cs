namespace ProyectoERP.Dominio.Entidades
{
    public class CuentaModel
    {
        public int Id { get; set; }
        public string NombreCuenta { get; set; }
        public string Descripcion { get; set; }
        public string Color {  get; set; }
        public DateTime FechaDeCreacion { get; set; }

    }
}
