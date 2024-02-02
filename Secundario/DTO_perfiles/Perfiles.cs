using AutoMapper;
using Principal.Models;
using Secundario.DTO;
using Secundario.Models;
namespace Secundario.DTO_perfiles
{
    public class Perfiles : Profile
    {
        public Perfiles()
        {
            CreateMap<Plato, PlatoReadDTO>();
            CreateMap<DetalleCreateDTO, DetalleReadDTO>();
            CreateMap<DetalleCreateDTO, Detalle>();
            CreateMap<PlatoPublisherDTO, Plato>().ForMember(
                destino => destino.fid,
                opcion => opcion.MapFrom(fuente => fuente.id)
                );
        }
    }
}
