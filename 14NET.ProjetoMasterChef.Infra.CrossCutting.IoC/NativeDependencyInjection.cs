using System;
using _14NET.ProjetoMasterChef.Application;
using _14NET.ProjetoMasterChef.Application.Interfaces;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Repository;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Services;
using _14NET.ProjetoMasterChef.Domain.Service;
using _14NET.ProjetoMasterChef.Infra.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _14NET.ProjetoMasterChef.Infra.CrossCutting.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<IReceitaAppService, ReceitaAppService>();

            //Domain Layer
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IReceitaService, ReceitaService>();

            //Infra Layer
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();
        }
    }
}
