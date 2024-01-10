using Microsoft.AspNetCore.Mvc;
using Principal.Models;
using Principal.Repos;

namespace Principal.Controllers
{
    [ApiController]
    [Route("api/plato")]//[Route("api/controller")]
    public class PlatoController : ControllerBase
    {
        private readonly IPlatoRepository repo;
        public PlatoController(IPlatoRepository repo) {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Plato>> GetPlatos()
        {
            var platos = repo.GetPlatos();
            return Ok(platos);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Plato>> GetPlatoById(int id)
        {
            var plato = repo.GetPlatoById(id);
            return Ok(plato);
        }

    }
}
