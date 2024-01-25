using Microsoft.AspNetCore.Mvc;

namespace Secundario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public PedidoController()
        {
            
        }
        [HttpPost]
        public ActionResult Post()
        {
            Console.WriteLine("Llegó una petición al servicio Pedido");
            return Ok("Respuesta exitosa desde el controlador Pedido");
        }
    }
}
