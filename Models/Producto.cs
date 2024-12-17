namespace ExamenAPIRestFul.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public bool? Enabled { get; set; }


        //Relacion con Categoria
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
    }
}
