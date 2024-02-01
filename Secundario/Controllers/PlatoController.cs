using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Secundario.Conexion;
using Secundario.DTO;

namespace Secundario.Controllers
{
    [Route("api/pedido/Plato")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly IDetalleRepository repo;
        private readonly IMapper mapper;

        public PlatoController(IDetalleRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatoReadDTO>> GetPlatos()
        {
            Console.WriteLine("Se obtienen platos (mediante servicio Pedido)");
            var platos = repo.GetPlatos();
            return Ok(mapper.Map<IEnumerable<PlatoReadDTO>>(platos));
        }
    }
}
