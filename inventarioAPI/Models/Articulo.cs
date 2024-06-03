namespace inventarioAPI.Models
{
    public class Articulo
    {
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int Existencia { get; set; }
    public int IdentificadorTipoInventario { get; set; }
    public decimal CostoUnitario { get; set; }
    public string Estado { get; set; }
    public DateTime FechaCreacion { get; set; }  // Campo adicional
    public DateTime FechaActualizacion { get; set; }  // Campo adicional

    // Relación con TipoInventario
    public TipoInventario TipoInventario { get; set; }

    // Relación con ExistenciasXAlmacen
    public ICollection<ExistenciasXAlmacen> ExistenciasXAlmacenes { get; set; }

    // Relación con Transacciones
    public ICollection<Transaccion> Transacciones { get; set; }
    }
}
