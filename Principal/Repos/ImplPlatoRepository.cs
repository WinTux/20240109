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
        public Plato GetPlatoById(int codigo)
        {
            return _context.platos.FirstOrDefault(p => p.id == codigo);
        }

        public IEnumerable<Plato> GetPlatos()
        {
            return _context.platos.ToList();
        }
    }
}
