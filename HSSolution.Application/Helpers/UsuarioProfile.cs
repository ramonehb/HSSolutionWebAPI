using AutoMapper;
using HSSolution.Application.Dtos;
using HSSolution.Domain;

namespace HSSolution.Application.Helpers;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() 
    {
        CreateMap<Usuario, UsuarioInputModel>().ReverseMap();

        CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
    }
}
