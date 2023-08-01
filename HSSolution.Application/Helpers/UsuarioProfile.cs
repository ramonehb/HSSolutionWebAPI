using AutoMapper;
using HSSolution.Application.Dtos;
using HSSolution.Domain;

namespace HSSolution.Application.Helpers;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() 
    {
        CreateMap<UsuarioInputModel, Usuario>().ReverseMap();

        CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
    }
}
