
using AutoMapper;
using Usuarios.Aplicacion.Usuario.Comandos;
using Usuarios.Aplicacion.Usuario.Dto;

namespace Usuarios.Aplicacion.Usuario.Mapeadores
{
    public class UsuarioMapeador : Profile
    {
        public UsuarioMapeador() 
        {

            CreateMap<Dominio.Entidades.Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioDto, UsuarioOut>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => src.IdRol));
            CreateMap<UsuarioCrearComando, Dominio.Entidades.Usuario>().ReverseMap(); 
        }
    }
}
