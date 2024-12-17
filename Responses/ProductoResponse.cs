namespace ExamenAPIRestFul.Responses
{
    public class ProductoResponse
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        
        //Relacion con Categoria
        public int CategoriaID { get; set; }
        //public string NombreCateg { get; set; }
    }
}
