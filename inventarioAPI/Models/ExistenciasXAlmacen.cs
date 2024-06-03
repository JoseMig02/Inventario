namespace inventarioAPI.Models
{
    public class ExistenciasXAlmacen
    {
    public int Id { get; set; }
    public int IdAlmacen { get; set; }
    public int IdArticulo { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaUltimaActualizacion { get; set; }  // Campo adicional

    // Relación con Almacen
    public Almacen Almacen { get; set; }

    // Relación con Articulo
    public Articulo Articulo { get; set; }
    }
}
