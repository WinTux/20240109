using Principal.DTO;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Principal.ComunicacionAsync
{
    public class ImplBusDeMensajesCliente : IBusDeMensajesCliente
    {
        private readonly IConfiguration configuration;
        private readonly IConnection connection;
        private readonly IModel canal;
        public void RabbitMQ_evento_shutdown(object sender, ShutdownEventArgs args) {
            Console.WriteLine("Se desconecta de RabbitMQ y algo podria ejecutarse ahora.");
            //codigo de interes
        }
        public ImplBusDeMensajesCliente(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionFactory factory = new ConnectionFactory() { 
                HostName = configuration["Host_RabbitMQ"],
                Port = int.Parse(configuration["Puerto_RabbitMQ"])
            };
            try { 
                connection = factory.CreateConnection();
                canal = connection.CreateModel();
                canal.ExchangeDeclare(
                    exchange: "mi_exxhange",
                    type: ExchangeType.Fanout
                    );
                connection.ConnectionShutdown += RabbitMQ_evento_shutdown;
            } catch (Exception e){
                Console.WriteLine($"Error al tratar de establecer conexion con RabbitMQ: {e.Message}");
            }
        }
        public void PublicarNuevoPlato(PlatoPublisherDTO platoPublisherDTO)
        {
            string mensaje = JsonSerializer.Serialize(platoPublisherDTO);
            if (connection.IsOpen)
                Enviar(mensaje);
            else
                Console.WriteLine("No se pudo enviar el mensaje al bus de mensajes RabbitMQ");

        }

        private void Enviar(string mensaje)
        {
            var cuerpo = Encoding.UTF8.GetBytes(mensaje);
            canal.BasicPublish(
                exchange: "mi_exxhange",
                routingKey: "",
                basicProperties: null,
                body: cuerpo
                );
            Console.WriteLine("Se envio el mensaje al bus de mensajes RabbitMQ");
        }

        private void Finalizar() {
            if (canal.IsOpen)
            {
                canal.Close();
                connection.Close();
            }
        }
    }
}
