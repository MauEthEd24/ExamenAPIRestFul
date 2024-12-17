using ExamenAPIRestFul.Models;
using ExamenAPIRestFul.Requests;
using ExamenAPIRestFul.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenAPIRestFul.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpPost]
        public void Insert(ProductRequest productRequest)
        {
            using (var context = new ProductCategContext())
            {
                Producto producto = new Producto
                {
                    NombreProducto = productRequest.NombreProducto,
                    Precio = productRequest.Precio,
                    Enabled = true,
                    CategoriaID = productRequest.CategoriaID
                };
                context.Productos.Add(producto);
                context.SaveChanges();
            }
        }


        //LISTAR TODOS LOS PRODUCTOS
        [HttpGet]
        public List<ProductoResponse> ListarTodoProductos()
        {
            using (var context = new ProductCategContext())
            {
                var productos = context.Productos.ToList();

                var response = productos.Select(x => new ProductoResponse
                {
                    ProductoID = x.ProductoID,
                    NombreProducto = x.NombreProducto,
                    Precio = x.Precio,
                    CategoriaID=x.CategoriaID
                }).ToList();

                return response;
            }
        }


        //LISTAR PRODUCTOS POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductPorID(int id)
        {

            using (var context = new ProductCategContext())
            {
                var producto = await context.Productos.FindAsync(id);

                if (producto == null)
                {
                    return NotFound();
                }

                return producto;

            }

        }
    }
}
