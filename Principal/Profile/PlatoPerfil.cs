using AutoMapper;
using Principal.DTO;
using Principal.Models;

namespace Principal.Perfil
{
    public class PlatoPerfil : Profile
    {
        public PlatoPerfil()
        {
            CreateMap<Plato, PlatoReadDTO>();// -->
            CreateMap<PlatoCreateDTO, Plato>();// -->
            CreateMap<PlatoUpdateDTO, Plato>();// -->
        }
    }
}
