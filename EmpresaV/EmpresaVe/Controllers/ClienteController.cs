
using EmpresaVBLL.Servicios.Cliente;
using EmpresaVObjetos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteServicio.ObtenerClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _clienteServicio.ObtenerClientePorIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteViewModel cliente)
        {
            var nuevo = await _clienteServicio.CrearClienteAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }
    }
}