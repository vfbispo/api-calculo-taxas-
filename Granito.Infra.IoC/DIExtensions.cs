using Granito.Domain.Configurations;
using Granito.Domain.Interfaces.Services;
using Granito.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Granito.Infra.IoC
{
    public static class DIExtensions
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Services
            services.AddScoped<ITaxasService, TaxasService>();
            #endregion


            #region options
            services.Configure<TaxasConfigOptions>(opt => configuration.GetSection("Taxas").Bind(opt));

            #endregion
        }
    }
}
