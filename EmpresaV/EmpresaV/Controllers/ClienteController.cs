
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteViewModel cliente)
        {
            if (id != cliente.Id) return BadRequest();

            var actualizado = await _clienteServicio.ActualizarClienteAsync(cliente);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _clienteServicio.EliminarClienteAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
