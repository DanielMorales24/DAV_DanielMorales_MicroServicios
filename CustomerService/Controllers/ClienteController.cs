using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class ClienteController : ControllerBase
    {
        private static readonly List<Cliente> clientes = new()
        {
            new Cliente { Id = 1, Nombre = "Daniel Morales" },
            new Cliente { Id = 2, Nombre = "Ana Giron" }
        };

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            return cliente != null ? Ok(cliente) : NotFound();
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
