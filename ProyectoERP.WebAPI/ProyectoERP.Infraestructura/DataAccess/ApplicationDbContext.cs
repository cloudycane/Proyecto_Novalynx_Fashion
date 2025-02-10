using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;

namespace ProyectoERP.Infraestructura.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<CategoriaIngresoModel> CategoriasIngreso { get; set; }
        public virtual DbSet<CategoriaGastoModel> CategoriasGasto { get; set;}
        public virtual DbSet<SuministradorModel> Suministradores { get; set; }
        public virtual DbSet<ProductoSuministradorModel> ProductosSuministradores { get; set; }

        public virtual DbSet<CuentaModel> Cuentas {  get; set; }

    }
}
