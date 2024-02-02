using AutoMapper;
using Principal.Models;
using Secundario.Conexion;
using Secundario.DTO;
using System.Text.Json;

namespace Secundario.Eventos
{
    public class ProcesadorDeEventos : IProcesador_de_Eventos
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IMapper mapper;

        public ProcesadorDeEventos(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.mapper = mapper;
        }
        public void ProcesarEvento(string msj)
        {
            var tipo = DeterminarEvento(msj);
            switch(tipo)
            {
                case TipoDeEvento.plato_publicado:
                    agregarPlato(msj);
                    break;
                case TipoDeEvento.desconocido:
                    break;
            }
        }

        private TipoDeEvento DeterminarEvento(string mensaje)
        {
            EventoDTO tipo = JsonSerializer.Deserialize<EventoDTO>(mensaje);
            switch (tipo.evento)
            {
                case "plato_publicado":
                    return TipoDeEvento.plato_publicado;
                default:
                    return TipoDeEvento.desconocido;
            }
                
        }
        private void agregarPlato(string mensajePlatoPublisher)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IDetalleRepository>();
                var platoPublisherDTO = JsonSerializer.Deserialize<PlatoPublisherDTO>(mensajePlatoPublisher);
                try
                {
                    var plato = mapper.Map<Plato>(platoPublisherDTO);
                    if(!repo.ExistePlatoForaneo(plato.fid))
                    {
                        repo.CrearPlato(plato);
                        repo.Guardar();
                    }
                }catch(Exception ex) {
                    Console.WriteLine($"Error al agregar plato a la DDBB local. {ex.Message}");
                }
            }
        }
    }
    enum TipoDeEvento { 
        plato_publicado,
        desconocido
    }
}
