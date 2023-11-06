using Application.Dtos.UsuarioDtos;
using AutoMapper;
using Domain.Entidades;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, InserirUsuarioDto>().ReverseMap();
            CreateMap<UsuarioDto, Usuario>().ReverseMap();

        }
    }
}
