
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Secundario.Eventos;
using System.Text;

namespace Secundario.ComunicacionAsync
{
    public class BusDeMensajesSuscriptor : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly IProcesador_de_Eventos procesador_De_Eventos;
        private IConnection conexion;
        private IModel canal;
        private string cola;

        public BusDeMensajesSuscriptor(IConfiguration configuration, IProcesador_de_Eventos procesador_De_Eventos)
        {
            this.configuration = configuration;
            this.procesador_De_Eventos = procesador_De_Eventos;
            InciciarRabbitMQ();
        }

        private void InciciarRabbitMQ()
        {
            var factory = new ConnectionFactory() {
                HostName = configuration["Host_RabbitMQ"],
                Port = int.Parse(configuration["Puerto_RabbitMQ"])
            };
            conexion = factory.CreateConnection();
            canal = conexion.CreateModel();
            canal.ExchangeDeclare(
                exchange: "mi_exchange",
                type: ExchangeType.Fanout
                );
            cola = canal.QueueDeclare().QueueName;
            canal.QueueBind(
                queue: cola,
                exchange: "mi_exchange",
                routingKey: ""
                );
        }
        public override void Dispose()
        {
            if (canal.IsOpen)
            {
                canal.Close();
                conexion.Close();
            }
            base.Dispose();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumidor = new EventingBasicConsumer(canal);
            consumidor.Received += (modulo, eveArgs) => {
                Console.WriteLine("Un evento ocurrio");
                var cuerpo = eveArgs.Body;
                var mensaje = Encoding.UTF8.GetString(cuerpo.ToArray());
                procesador_De_Eventos.ProcesarEvento(mensaje);
            };
            canal.BasicConsume(
                queue: cola,
                autoAck: true,
                consumer: consumidor
                );
            return Task.CompletedTask;
        }
    }
}
