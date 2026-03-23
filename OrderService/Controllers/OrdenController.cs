using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdenController : ControllerBase
    {
        private static readonly List<Orden> ordenes = new()
        {
            new Orden { Id = 1, ClienteId = 1, ProductoId = 1, Cantidad = 1 },
            new Orden { Id = 2, ClienteId = 2, ProductoId = 3, Cantidad = 2 }
        };

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var orden = ordenes.FirstOrDefault(o => o.Id == id);
            return orden != null ? Ok(orden) : NotFound();
        }
    }

    public class Orden
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
