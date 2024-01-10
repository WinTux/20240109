using Principal.Models;

namespace Principal.Repos
{
    public class ImplPlatoRepository : IPlatoRepository
    {
        public Plato GetPlatoById(int id)
        {
            var plato = new Plato
            {
                id = 1,
                nombre = "Silpancho",
                ingredientes = "Carne, arroz, papa, huevo",
                precio = 10
            };
            return plato;
        }

        public IEnumerable<Plato> GetPlatos()
        {
            var platos = new List<Plato> { 
                new Plato
                {
                    id = 1,
                    nombre = "Silpancho",
                    ingredientes = "Carne, arroz, papa, huevo",
                    precio = 10
                },
                new Plato
                {
                    id = 2,
                    nombre = "Fricase",
                    ingredientes = "Pollo, etc.",
                    precio = 20
                },
                new Plato
                {
                    id = 3,
                    nombre = "Majadito",
                    ingredientes = "huevo, arroz, carne, charque",
                    precio = 15
                }
            };
            return platos;
        }
    }
}
