using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpresaVObjetos.ViewModels;


namespace EmpresaVBLL.Servicios.Cliente
{
    public interface IClienteServicio
    {
        Task<List<ClienteViewModel>> ObtenerClientesAsync();
        Task<ClienteViewModel> ObtenerClientePorIdAsync(int id);
        Task<ClienteViewModel> CrearClienteAsync(ClienteViewModel cliente);
        Task<ClienteViewModel> ActualizarClienteAsync(ClienteViewModel cliente);
        Task<bool> EliminarClienteAsync(int id);
    }
}
