using BusinessLayer;
using BusinessLayer.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProvider<Rover>, Calculate>();
        }
    }
}
