using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductoController : ControllerBase
    {
        private static readonly List<Producto> productos = new()
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 45 }
        };

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            return producto != null ? Ok(producto) : NotFound();
        }

        [HttpGet("destacados")]
        public IActionResult ObtenerDestacados()
        {
            return Ok(productos.Take(2));
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; }
    }
}
