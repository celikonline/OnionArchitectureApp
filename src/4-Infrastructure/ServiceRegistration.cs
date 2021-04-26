using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Efactura.Application.Interfaces.Repositories;
using Efactura.Persistence.Context;
using Efactura.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Efactura.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));

            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
