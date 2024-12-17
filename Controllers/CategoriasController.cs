using ExamenAPIRestFul.Models;
using ExamenAPIRestFul.Requests;
using ExamenAPIRestFul.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPIRestFul.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpPost]
        public void Insert(CategoriaRequest categoriaRequest)
        {
            using (var context = new ProductCategContext())
            {
                Categoria categoria = new Categoria
                {
                    NombreCateg = categoriaRequest.NombreCateg,
                    Descripcion = categoriaRequest.Descripcion
                };
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }


        [HttpGet]
        public List<CategoriaResponse> ListarCategorias()
        {
            using (var context = new ProductCategContext())
            {
                var categorias = context.Categorias.ToList();

                var response = categorias.Select(x => new CategoriaResponse
                {
                    CategoriaID = x.CategoriaID,
                    NombreCateg= x.NombreCateg,
                    Descripcion= x.Descripcion
                }).ToList();

                return response;
            }           
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaPorID(int id)
        {

            using (var context = new ProductCategContext())
            {
                var categoria = await context.Categorias.FindAsync(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                return categoria;

            }
            
        }
    }
}
