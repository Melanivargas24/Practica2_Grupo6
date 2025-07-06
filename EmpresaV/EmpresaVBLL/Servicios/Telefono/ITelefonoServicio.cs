using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpresaVObjetos.ViewModels;

namespace EmpresaVBLL.Servicios.Telefono
{
    public interface ITelefonoServicio
    {
        Task<List<TelefonoViewModel>> ObtenerTelefonosAsync();
        Task<List<TelefonoViewModel>> ObtenerTelefonosPorClienteIdAsync(int clienteId);
        Task<TelefonoViewModel> ObtenerTelefonoPorIdAsync(int id);
        Task<TelefonoViewModel> CrearTelefonoAsync(TelefonoViewModel telefono);
        Task<TelefonoViewModel> ActualizarTelefonoAsync(TelefonoViewModel telefono);
        Task<bool> EliminarTelefonoAsync(int id);
    }
}
