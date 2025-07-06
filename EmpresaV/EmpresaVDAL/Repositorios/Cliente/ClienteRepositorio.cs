using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpresaVObjetos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EmpresaVDAL.Repositorios.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly EmpresaContext _context;

        public ClienteRepositorio(EmpresaContext context)
        {
            _context = context;
        }

        public async Task<List<EmpresaVObjetos.Modelos.Cliente>> ObtenerClientesAsync()
        {
            return await _context.Cliente
                .Include(c => c.Telefonos)
                .ToListAsync();
        }

        public async Task<EmpresaVObjetos.Modelos.Cliente> ObtenerClientePorIdAsync(int id)
        {
            return await _context.Cliente
                .Include(c => c.Telefonos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<EmpresaVObjetos.Modelos.Cliente> CrearClienteAsync(EmpresaVObjetos.Modelos.Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<EmpresaVObjetos.Modelos.Cliente> ActualizarClienteAsync(EmpresaVObjetos.Modelos.Cliente cliente)
        {
            var existente = await _context.Cliente
                .Include(c => c.Telefonos)
                .FirstOrDefaultAsync(c => c.Id == cliente.Id);

            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(cliente);

           
            _context.Telefono.RemoveRange(existente.Telefonos);
            await _context.SaveChangesAsync();

            existente.Telefonos = cliente.Telefonos;
            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return false;

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
