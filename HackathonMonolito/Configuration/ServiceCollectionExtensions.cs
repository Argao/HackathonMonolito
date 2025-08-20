using System.Data;
using HackathonMonolito.Repositories;
using HackathonMonolito.Repositories.Interfaces;
using HackathonMonolito.Services;
using HackathonMonolito.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HackathonMonolito.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ProdutosDb")
                               ?? throw new InvalidOperationException("Connection string 'ProdutosDb' não encontrada.");

        var connectionStringLocal = configuration.GetConnectionString("LocalDb") 
                                  ?? throw new InvalidOperationException("Connection string 'LocalDb' não encontrada.");
        
        services.AddSingleton<Func<IDbConnection>>(_ =>
        {
            return () => new SqlConnection(connectionString);
        });

        // Configuração simples do SQLite
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(connectionStringLocal);
        });

        //Repositories
        services.AddScoped<IProdutoRepository, SqlServerProdutoRepository>();
        services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();
        
        //Services
        services.AddScoped<ISimulacaoService, SimulacaoService>();
        
        
        // Calculadoras
        services.AddScoped<ICalculadoraAmortizacao, CalculadoraSAC>();
        services.AddScoped<ICalculadoraAmortizacao, CalculadoraPRICE>();

        return services;
    }
}