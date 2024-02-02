using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secundario.ComunicacionAsync;
using Secundario.Conexion;
using Secundario.Eventos;
namespace Secundario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<PedidoDbContext>(op=> op.UseInMemoryDatabase("miDb"));
            builder.Services.AddSingleton<IProcesador_de_Eventos, ProcesadorDeEventos>();
            builder.Services.AddHostedService<BusDeMensajesSuscriptor>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
