using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using EmpresaVDAL.Repositorios.Cliente;
using EmpresaVObjetos.ViewModels;

namespace EmpresaVBLL.Servicios.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ClienteViewModel>> ObtenerClientesAsync()
        {
            var clientes = await _clienteRepositorio.ObtenerClientesAsync();
            return _mapper.Map<List<ClienteViewModel>>(clientes);
        }

        public async Task<ClienteViewModel> ObtenerClientePorIdAsync(int id)
        {
            var cliente = await _clienteRepositorio.ObtenerClientePorIdAsync(id);
            return _mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<ClienteViewModel> CrearClienteAsync(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<EmpresaVObjetos.Modelos.Cliente>(clienteViewModel);
            var resultado = await _clienteRepositorio.CrearClienteAsync(cliente);
            return _mapper.Map<ClienteViewModel>(resultado);
        }

        public async Task<ClienteViewModel> ActualizarClienteAsync(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<EmpresaVObjetos.Modelos.Cliente>(clienteViewModel);
            var resultado = await _clienteRepositorio.ActualizarClienteAsync(cliente);
            return _mapper.Map<ClienteViewModel>(resultado);
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            return await _clienteRepositorio.EliminarClienteAsync(id);
        }
    }
}
