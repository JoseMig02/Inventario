namespace inventarioAPI.Models
{
    public class TipoInventario
    {
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public string CuentaContable { get; set; }
    public string Estado { get; set; }
    public DateTime FechaCreacion { get; set; }  // Campo adicional
    public DateTime FechaActualizacion { get; set; }  // Campo adicional

    // Relación con Articulo
    public ICollection<Articulo> Articulos { get; set; }
    }
}
