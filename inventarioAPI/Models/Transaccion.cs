using System;

namespace inventarioAPI.Models
{
    public class Transaccion
    {
           public int? Id { get; set; } 
        public string TipoTransaccion { get; set; }  // Entrada, Salida, Traslado, Ajuste
        public int IdArticulo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public string Observaciones { get; set; }

    
    }
}
