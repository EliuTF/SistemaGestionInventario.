using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Modelos;
using System.Collections.Generic;

namespace SistemaGestionInventario
{
    public class ConexionDB : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tu_servidor;Database=InventarioDB;Trusted_Connection=True;");
        }
    }
}
