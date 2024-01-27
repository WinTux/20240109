using Principal.DTO;

namespace Principal.ComunicacionSync.Http
{
    public interface ISecundarioPedidoCliente
    {
        Task ComunicarseConSecundario(PlatoReadDTO plato);
    }
}
