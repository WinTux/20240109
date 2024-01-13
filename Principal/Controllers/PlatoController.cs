using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Principal.DTO;
using Principal.Models;
using Principal.Repos;

namespace Principal.Controllers
{
    [ApiController]
    [Route("api/plato")]//[Route("api/controller")]
    public class PlatoController : ControllerBase
    {
        private readonly IPlatoRepository repo;
        private readonly IMapper mapper;
        public PlatoController(IPlatoRepository repo, IMapper mapper) {
            this.repo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatoReadDTO>> GetPlatos()
        {
            var platos = repo.GetPlatos();
            return Ok(mapper.Map<IEnumerable<PlatoReadDTO>>(platos));
        }
        [HttpGet("{id}", Name = "GetPlatoById")]
        public ActionResult<PlatoReadDTO> GetPlatoById(int id)
        {
            var plato = repo.GetPlatoById(id);
            if(plato != null)
                return Ok(mapper.Map<PlatoReadDTO>(plato));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatoReadDTO> SetPlato(PlatoCreateDTO platoCreateDTO) { 
            Plato plato = mapper.Map<Plato>(platoCreateDTO);
            repo.AddPlato(plato);
            repo.Guardar();
            PlatoReadDTO platoRetorno = mapper.Map<PlatoReadDTO>(plato);
            return CreatedAtRoute(nameof(GetPlatoById), new { id = plato.id }, platoRetorno);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlato(int id, PlatoUpdateDTO platoUpdateDTO) { 
            Plato plato = repo.GetPlatoById(id);
            if (plato == null)
                return NotFound();
            platoUpdateDTO.id = plato.id;
            mapper.Map(platoUpdateDTO, plato);
            repo.UpdatePlato(plato);//Escalabilidad
            repo.Guardar();
            return NoContent();
        }
    }
}
