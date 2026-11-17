using Microsoft.Extensions.DependencyInjection;
using PampasControleBeneficios.Aplicacao.Services;

namespace PampasControleBeneficios.Aplicacao.Extensions;

public static class AplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<BeneficioService>();
        services.AddScoped<FuncionarioService>();
        services.AddScoped<TipoBeneficioService>();

        return services;
    }
}