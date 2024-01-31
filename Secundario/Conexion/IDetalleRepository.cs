using Principal.Models;
using Secundario.Models;

namespace Secundario.Conexion
{
    public interface IDetalleRepository
    {
        //Para platos
        IEnumerable<Plato> GetPlatos();
        void CrearPlato(Plato plato);
        bool ExistePlato(int id);

        //Para detalle
        Detalle GetDetalle(int iddetalle, int idplato);
        IEnumerable<Detalle> GetDetallesDePlato(int id);
        void CrearDetalle(int idplato, Detalle detalle);

        bool Guardar();
    }
}
