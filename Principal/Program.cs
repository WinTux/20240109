using Microsoft.EntityFrameworkCore;
using Principal.Repos;
using Newtonsoft.Json.Serialization;
using Principal.ComunicacionSync.Http;

namespace Principal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson( s => 
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            builder.Services.AddDbContext<RestaurantDbContext>(op => 
                op.UseSqlServer(builder.Configuration.GetConnectionString("una_conexion")));
            builder.Services.AddHttpClient<ISecundarioPedidoCliente, ImplHttpSecundarioPedidoCliente>();
            builder.Services.AddScoped<IPlatoRepository,ImplPlatoRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

            var app = builder.Build();

            //Esta en mal lugar
            /*if (!app.Environment.IsDevelopment())
            {
                Console.WriteLine("Conectandose a DDBB produccion");
                builder.Services.AddDbContext<RestaurantDbContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantProd")));
            }
            */
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
