namespace inventarioAPI.Models
{
    public class Almacen
    {
        public int Id { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }
    public string Direccion { get; set; }  // Campo adicional
    public DateTime FechaCreacion { get; set; }  // Campo adicional
    public DateTime FechaActualizacion { get; set; }  // Campo adicional

    // Relación con ExistenciasXAlmacen
    public ICollection<ExistenciasXAlmacen> ExistenciasXAlmacenes { get; set; }
    }
}
