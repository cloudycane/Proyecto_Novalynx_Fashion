using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovalynxFashion.Core.Entidades;
using NovalynxFashion.Core.Entidades.IdentityEntities;

namespace NovalynxFashion.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SuministradorModel> Suministradores {  get; set; }
        public DbSet<ProductoSuministradorModel> ProductoSuministradores { get; set; }
        public DbSet<OrdenesEnCarritoModel> OrdenesEnCarrito { get; set; }
        public DbSet<InventarioModel> Inventarios {  get; set; }
        public DbSet<ProductosEnProduccionModel> ProductosEnVentas { get; set; }
        
        public DbSet<ProductosParaLaVentaModel> ProductosParaLaVenta { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventarioModel>()
                .HasOne(i => i.OrdenCarrito)
                .WithMany()
                .HasForeignKey(i => i.OrdenCarritoId)
                .OnDelete(DeleteBehavior.NoAction);

          
            modelBuilder.Entity<ProductosEnProduccionModel>()
                .HasMany(p => p.Ingredientes)
                .WithMany(i => i.ProductosEnVentas)
                .UsingEntity(j => j.ToTable("ProductosEnVentasIngredientes")); // Use a join table
       
            
        }

    }
}

