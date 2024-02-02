using Principal.Models;
using Secundario.Models;

namespace Secundario.Conexion
{
    public class ImplDetalleRepository : IDetalleRepository
    {
        private readonly PedidoDbContext _context;
        public ImplDetalleRepository(PedidoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Plato> GetPlatos()
        {
            return _context.platos.ToList();
        }
        

        public void CrearPlato(Plato plato)
        {
            if (plato == null)
            {
                throw new ArgumentNullException(nameof(plato));
            }
            else
                _context.platos.Add(plato);
        }

        public bool ExistePlato(int id)
        {
            return _context.platos.Any(p => p.id == id);
        }

        public void CrearDetalle(int idplato, Detalle detalle)
        {
            if(detalle == null)
                throw new ArgumentNullException(nameof(detalle));
            else
            {
                detalle.platoID = idplato;
                _context.detalles.Add(detalle);
            }

        }

        public Detalle GetDetalle(int iddetalle, int idplato)
        {
            return _context.detalles.Where(dt => dt.id == iddetalle && dt.platoID == idplato).FirstOrDefault();
        }

        public IEnumerable<Detalle> GetDetallesDePlato(int id)
        {
            return _context.detalles.Where(d => d.platoID == id).OrderBy(d => d.plato.nombre);
        }

        

        public bool Guardar()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ExistePlatoForaneo(int fid)
        {
            return _context.platos.Any(p => p.fid == fid);
        }
    }
}
