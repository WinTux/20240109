using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Secundario.Conexion;
using Secundario.DTO;
using Secundario.Models;

namespace Secundario.Controllers
{
    [Route("api/pedido/Detalle/{platoid}")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private readonly IDetalleRepository repo;
        private readonly IMapper mapper;
        public DetalleController(IDetalleRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DetalleReadDTO>> GetDetallesDePlato(int platoid) {
            Console.WriteLine($"Se obtienen detalles del plato con ID: {platoid}");
            if (!repo.ExistePlato(platoid))
                return NotFound();
            var detalles = repo.GetDetallesDePlato(platoid);
            return Ok(mapper.Map<IEnumerable<DetalleReadDTO>>(detalles));
        }

        [HttpGet("{detalleid}", Name = "GetDetalleDePlato")]
        public ActionResult<DetalleReadDTO> GetDetalleDePlato(int platoid, int detalleid)
        {
            Console.WriteLine($"Se obtiene el detalle {detalleid} del plato con ID: {platoid}");
            if (!repo.ExistePlato(platoid))
                return NotFound();
            var detalle = repo.GetDetalle(detalleid,platoid);
            if(detalle == null)
                return NotFound();
            return Ok(mapper.Map<DetalleReadDTO>(detalle));
        }

        [HttpPost]
        public ActionResult<DetalleReadDTO> CrearDetalleParaPlato(int platoid, DetalleCreateDTO detalleDTO) {
            Console.WriteLine($"Se e crea detalle para plato con ID: {platoid}");
            if(!repo.ExistePlato(platoid))
                return NotFound();
            Detalle detalle = mapper.Map<Detalle>(detalleDTO);
            repo.CrearDetalle(platoid, detalle);
            repo.Guardar();
            var detalleReadDTO = mapper.Map<DetalleReadDTO>(detalle);
            return CreatedAtRoute(nameof(GetDetalleDePlato), new { platoid = platoid, detalleid = detalleReadDTO.id }, detalleReadDTO);
        }
    }
}
