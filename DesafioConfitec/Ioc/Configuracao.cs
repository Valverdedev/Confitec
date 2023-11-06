using Application.AppService;
using Application.AutoMapper;
using Application.Interfaces;
using Domain.Repository;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Domain.Services;
using Infra_db.Context;
using Infra_db.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc
{
    public static class Configuracao
    {

       public static void InjecaoDeDependencia(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextSql>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbContext"));
                
            });
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            services.AddAutoMapper(typeof(MappingProfile));

        }
    }
}
