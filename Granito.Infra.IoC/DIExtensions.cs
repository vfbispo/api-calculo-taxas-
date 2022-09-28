using Granito.Domain.Configurations.ApiCalculoJuros;
using Granito.Domain.Configurations.ApiRetornoTaxaJuros;
using Granito.Domain.Interfaces.Services;
using Granito.Domain.Interfaces.Webservices;
using Granito.Domain.Services;
using Granito.Services.WebService.Taxas;
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
            services.AddScoped<IJurosCompostosService, JurosCompostosService>();
            #endregion

            #region WebServices
            services.AddScoped<ITaxasJurosWebservice, TaxasJurosWebservice>();
            #endregion

            #region options
            #region API Retorno Taxas
            services.Configure<TaxasConfigOptions>(opt => configuration.GetSection("Taxas").Bind(opt));
            #endregion

            #region API Calculo Juros Compostos
            services.Configure<GithubConfigOptions>(opt => configuration.GetSection("Github").Bind(opt));
            services.Configure<APIsConfigOptions>(opt => configuration.GetSection("APIs").Bind(opt));

            #endregion
            #endregion
        }
    }
}
