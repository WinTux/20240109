using Principal.Models;

namespace Principal.Repos
{
    public interface IPlatoRepository
    {
        public IEnumerable<Plato> GetPlatos();
        public Plato GetPlatoById(int id);
        void AddPlato(Plato plato);
        bool Guardar();
        void UpdatePlato(Plato plato);
        void EliminarPlato(Plato plato);
    }
}
