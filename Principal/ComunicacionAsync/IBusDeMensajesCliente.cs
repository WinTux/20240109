using Principal.DTO;

namespace Principal.ComunicacionAsync
{
    public interface IBusDeMensajesCliente
    {
        void PublicarNuevoPlato(PlatoPublisherDTO platoPublisherDTO);
    }
}
