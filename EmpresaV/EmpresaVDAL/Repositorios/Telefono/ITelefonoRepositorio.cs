using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpresaVObjetos.Modelos;

namespace EmpresaVDAL.Repositorios.Telefono
{
    public interface ITelefonoRepositorio
    {
        Task<List<EmpresaVObjetos.Modelos.Telefono>> ObtenerTelefonosAsync();
        Task<List<EmpresaVObjetos.Modelos.Telefono>> ObtenerTelefonosPorClienteIdAsync(int clienteId);
        Task<EmpresaVObjetos.Modelos.Telefono> ObtenerTelefonoPorIdAsync(int id);
        Task<EmpresaVObjetos.Modelos.Telefono> CrearTelefonoAsync(EmpresaVObjetos.Modelos.Telefono telefono);
        Task<EmpresaVObjetos.Modelos.Telefono> ActualizarTelefonoAsync(EmpresaVObjetos.Modelos.Telefono telefono);
        Task<bool> EliminarTelefonoAsync(int id);
    }
}
