using Principal.Models;

namespace Principal.Repos
{
    public class ImplPlatoRepository : IPlatoRepository
    {
        private readonly RestaurantDbContext _context;
        public ImplPlatoRepository(RestaurantDbContext context)
        {
            _context = context;   
        }

        public void AddPlato(Plato plato)
        {
            if(plato == null)
                throw new ArgumentNullException(nameof(plato));
            _context.platos.Add(plato);
        }

        public void EliminarPlato(Plato plato)
        {
            if (plato == null)
                throw new ArgumentNullException(nameof(plato));
            _context.platos.Remove(plato);
        }

        public Plato GetPlatoById(int codigo)
        {
            return _context.platos.FirstOrDefault(p => p.id == codigo);
        }

        public IEnumerable<Plato> GetPlatos()
        {
            return _context.platos.ToList();
        }

        public bool Guardar()
        {
            return (_context.SaveChanges() > -1);
        }

        public void UpdatePlato(Plato plato)
        {
            //No hacemos nada porque DbContext se encarga
        }
    }
}
