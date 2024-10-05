using Microsoft.Extensions.DependencyInjection;
using E_commerce.Application.Interfaces.AutoMapper;

namespace E_commerce.Mapper
{
    public static class Registration 
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
