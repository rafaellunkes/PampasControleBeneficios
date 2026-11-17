using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.Repositorios;

namespace PampasControleBeneficios.Infra.Extensions;

public static class InfraExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLite")
        ?? throw new InvalidOperationException("Connection string 'SQLite' não encontrada no appsettings.");

        services.AddScoped<IDbConnection>(_ => new SqliteConnection(connectionString));

        services.AddScoped<IBeneficioRepositorio, BeneficioRepositorio>();
        services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
        services.AddScoped<IItemPagamentoRepositorio, ItemPagamentoRepositorio>();
        services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();
        services.AddScoped<ITipoBeneficioRepositorio, TipoBeneficioRepositorio>();
        services.AddScoped<IFuncionarioBeneficioRepositorio, FuncionarioBeneficioRepositorio>();

        return services;
    }
}