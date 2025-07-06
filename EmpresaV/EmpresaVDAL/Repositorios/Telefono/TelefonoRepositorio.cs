using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpresaVObjetos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EmpresaVDAL.Repositorios.Telefono
{
    public class TelefonoRepositorio : ITelefonoRepositorio
    {
        private readonly EmpresaContext _context;

        public TelefonoRepositorio(EmpresaContext context)
        {
            _context = context;
        }

        public async Task<List<EmpresaVObjetos.Modelos.Telefono>> ObtenerTelefonosAsync()
        {
            return await _context.Telefono.Include(t => t.Cliente).ToListAsync();
        }

        public async Task<List<EmpresaVObjetos.Modelos.Telefono>> ObtenerTelefonosPorClienteIdAsync(int clienteId)
        {
            return await _context.Telefono
                .Where(t => t.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<EmpresaVObjetos.Modelos.Telefono> ObtenerTelefonoPorIdAsync(int id)
        {
            return await _context.Telefono.FindAsync(id);
        }

        public async Task<EmpresaVObjetos.Modelos.Telefono> CrearTelefonoAsync(EmpresaVObjetos.Modelos.Telefono telefono)
        {
            _context.Telefono.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<EmpresaVObjetos.Modelos.Telefono> ActualizarTelefonoAsync(EmpresaVObjetos.Modelos.Telefono telefono)
        {
            var existente = await _context.Telefono.FindAsync(telefono.Id);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(telefono);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> EliminarTelefonoAsync(int id)
        {
            var telefono = await _context.Telefono.FindAsync(id);
            if (telefono == null) return false;

            _context.Telefono.Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
