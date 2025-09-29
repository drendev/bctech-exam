using Infrastructure.Providers;

namespace ApiEndPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.InfrastructureServices(builder.Configuration);

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}
