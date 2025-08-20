using HackathonMonolito.DTO;
using HackathonMonolito.Models;

namespace HackathonMonolito.Repositories;

public interface ISimulacaoRepository
{
    Task<Simulacao> AdicionarAsync(Simulacao simulacao, CancellationToken ct);
    Task<PagedResponse<Simulacao>> ListarPaginadoAsync(PagedRequest request, CancellationToken ct);
}