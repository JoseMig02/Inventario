using System;

namespace inventarioAPI.Models
{
    public class ExistenciasXAlmacen
    {
           public int? Id { get; set; } 
        public int IdAlmacen { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
   
    }
}
