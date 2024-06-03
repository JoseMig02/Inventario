namespace inventarioAPI.Models
{
      public class Producto
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
