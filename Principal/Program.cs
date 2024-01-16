using Microsoft.EntityFrameworkCore;
using Principal.Repos;
using Newtonsoft.Json.Serialization;

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
            builder.Services.AddScoped<IPlatoRepository,ImplPlatoRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
