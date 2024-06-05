using System;
using System.Collections.Generic;

namespace inventarioAPI.Models
{
    public class Articulo
    {
         public int? Id { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public int IdTipoInventario { get; set; }
        public decimal CostoUnitario { get; set; }
        public string Estado { get; set; }

      
    }
}
