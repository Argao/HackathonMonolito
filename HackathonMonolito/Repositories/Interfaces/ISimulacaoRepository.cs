using HackathonMonolito.Models;

namespace HackathonMonolito.Repositories;

public interface ISimulacaoRepository
{
    Task<Simulacao> AdicionarAsync(Simulacao simulacao, CancellationToken ct);
}