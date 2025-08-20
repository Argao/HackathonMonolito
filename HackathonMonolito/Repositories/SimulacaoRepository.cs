using HackathonMonolito.Configuration;
using HackathonMonolito.Models;

namespace HackathonMonolito.Repositories;

public class SimulacaoRepository(AppDbContext context) : ISimulacaoRepository
{
    
    public async Task<Simulacao> AdicionarAsync(Simulacao simulacao, CancellationToken ct)
    {
        context.Simulacoes.Add(simulacao);
        await context.SaveChangesAsync(ct);
        return simulacao;
    }
    
}