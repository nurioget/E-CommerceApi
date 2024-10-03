using E_commerce.Aplication.Interfaces.Repositories;
using E_commerce.Aplication.Interfaces.UnitOfWork;
using E_commerce.Persistence.Context;
using E_commerce.Persistence.Repositories;
using E_commerce.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));

            services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
        }
    }
}
