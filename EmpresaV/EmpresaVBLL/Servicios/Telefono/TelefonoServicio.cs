using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using EmpresaVDAL.Repositorios.Telefono;
using EmpresaVObjetos.ViewModels;

namespace EmpresaVBLL.Servicios.Telefono
{
    public class TelefonoServicio : ITelefonoServicio
    {
        private readonly ITelefonoRepositorio _telefonoRepositorio;
        private readonly IMapper _mapper;

        public TelefonoServicio(ITelefonoRepositorio telefonoRepositorio, IMapper mapper)
        {
            _telefonoRepositorio = telefonoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<TelefonoViewModel>> ObtenerTelefonosAsync()
        {
            var telefonos = await _telefonoRepositorio.ObtenerTelefonosAsync();
            return _mapper.Map<List<TelefonoViewModel>>(telefonos);
        }

        public async Task<List<TelefonoViewModel>> ObtenerTelefonosPorClienteIdAsync(int clienteId)
        {
            var telefonos = await _telefonoRepositorio.ObtenerTelefonosPorClienteIdAsync(clienteId);
            return _mapper.Map<List<TelefonoViewModel>>(telefonos);
        }

        public async Task<TelefonoViewModel> ObtenerTelefonoPorIdAsync(int id)
        {
            var telefono = await _telefonoRepositorio.ObtenerTelefonoPorIdAsync(id);
            return _mapper.Map<TelefonoViewModel>(telefono);
        }

        public async Task<TelefonoViewModel> CrearTelefonoAsync(TelefonoViewModel telefonoViewModelo)
        {
            var telefono = _mapper.Map<EmpresaVObjetos.Modelos.Telefono>(telefonoViewModelo);
            var resultado = await _telefonoRepositorio.CrearTelefonoAsync(telefono);
            return _mapper.Map<TelefonoViewModel>(resultado);
        }

        public async Task<TelefonoViewModel> ActualizarTelefonoAsync(TelefonoViewModel telefonoViewModelo)
        {
            var telefono = _mapper.Map<EmpresaVObjetos.Modelos.Telefono>(telefonoViewModelo);
            var resultado = await _telefonoRepositorio.ActualizarTelefonoAsync(telefono);
            return _mapper.Map<TelefonoViewModel>(resultado);
        }

        public async Task<bool> EliminarTelefonoAsync(int id)
        {
            return await _telefonoRepositorio.EliminarTelefonoAsync(id);
        }
    }
}
