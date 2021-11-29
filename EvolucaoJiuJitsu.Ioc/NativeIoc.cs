using EvolucaoJiuJitsu.Dominio.Interfaces;
using EvolucaoJiuJitsu.Dominio.Interfaces.Repositorios;
using EvolucaoJiuJitsu.Dominio.Services;
using EvolucaoJiuJitsu.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EvolucaoJiuJitsu.Ioc
{
    public static class NativeIoc
    {
        public static void Register(this IServiceCollection services)
        {
            #region App Services
            services.AddTransient<IAlunoService, AlunoService>();
            #endregion

            #region Repositories
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            #endregion
        }
    }
}
