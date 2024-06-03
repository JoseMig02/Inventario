using inventarioAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace inventarioAPI.Data

{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
          public DbSet<Articulo> Articulos { get; set; }
    public DbSet<TipoInventario> TiposInventario { get; set; }
    public DbSet<Almacen> Almacenes { get; set; }
    public DbSet<ExistenciasXAlmacen> ExistenciasXAlmacenes { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
    }
}
