using BusinessLayer.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProvider<Rover>, Calculate>();
        }
    }
}
