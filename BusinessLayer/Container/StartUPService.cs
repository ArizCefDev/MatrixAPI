using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class StartUPService
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

    }
}
