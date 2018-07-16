using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using ProjetoBaseCore.Application.Interfaces;
using ProjetoBaseCore.Application.Services;
using ProjetoBaseCore.Domain.Core.Interfaces;
using ProjetoBaseCore.Domain.Interfaces;
using ProjetoBaseCore.Domain.Services;
using ProjetoBaseCore.Infra.CrossCutting.Jwt.Configs;
using ProjetoBaseCore.Infra.Data;
using ProjetoBaseCore.Infra.Data.Context;
using ProjetoBaseCore.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Infra.CrossCutting.IoC
{
    public class DependencyInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IPessoaAppService, PessoaAppService>();

            //Domain
            services.AddScoped<IPessoaService, PessoaService>();

            //Infra.Data
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainContext>();
        }
    }
}
