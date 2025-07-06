using AutoMapper;
using EmpresaVObjetos.Modelos;
using EmpresaVObjetos.ViewModels;

namespace EmpresaVObjetos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<ClienteViewModel, Cliente>(); 

            CreateMap<Telefono, TelefonoViewModel>();
            CreateMap<TelefonoViewModel, Telefono>(); 
        }
    }
}
