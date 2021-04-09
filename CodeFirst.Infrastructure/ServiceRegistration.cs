using CodeFirst.Core.Interfaces;
using CodeFirst.Core.Services;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Domain.Service;
using CodeFirst.Infrastructure.Repositories;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CodeFirstContext>(options =>
               options.UseSqlServer(connectionString: configuration.GetConnectionString("CodeFirst"),
               b => b.MigrationsAssembly(typeof(CodeFirstContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEstadoProyectoService, EstadoProyectoService>();
            services.AddTransient<IEstadoTareaService, EstadoTareaService>();
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<ITareaService, TareaService>();
            services.AddTransient<ISeguridadService, SeguridadService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICompletarProyectoService, CompletarProyectoService>();
            services.AddTransient<ICompletarTareaService, CompletarTareaService>();

            return services;
        }
    }
}