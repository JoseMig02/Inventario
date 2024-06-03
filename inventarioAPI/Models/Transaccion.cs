namespace inventarioAPI.Models
{
    public class Transaccion
    {
    public int Id { get; set; }
    public string TipoTransaccion { get; set; }  // Entrada, Salida, Traslado, Ajuste
    public int IdArticulo { get; set; }
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public decimal Costo { get; set; }  // Campo adicional
    public string Observaciones { get; set; }  // Campo adicional

    // Relación con Articulo
    public Articulo Articulo { get; set; }
    }
}
