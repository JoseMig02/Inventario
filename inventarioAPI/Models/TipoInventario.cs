using System;
using System.Collections.Generic;

namespace inventarioAPI.Models
{
    public class TipoInventario
    {
        public int? Id { get; set; } // Cambiado a tipo nullable
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CuentaContable { get; set; }
        public string Estado { get; set; }
    }
}
