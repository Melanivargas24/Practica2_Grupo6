using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpresaVObjetos.Modelos;

namespace EmpresaVDAL.Repositorios.Cliente
{
    public interface IClienteRepositorio
    {
        Task<List<EmpresaVObjetos.Modelos.Cliente>> ObtenerClientesAsync();
        Task<EmpresaVObjetos.Modelos.Cliente> ObtenerClientePorIdAsync(int id);
        Task<EmpresaVObjetos.Modelos.Cliente> CrearClienteAsync(EmpresaVObjetos.Modelos.Cliente cliente);
        Task<EmpresaVObjetos.Modelos.Cliente> ActualizarClienteAsync(EmpresaVObjetos.Modelos.Cliente cliente);
        Task<bool> EliminarClienteAsync(int id);
    }
}
