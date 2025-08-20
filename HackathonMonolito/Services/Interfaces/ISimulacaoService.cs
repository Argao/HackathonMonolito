using HackathonMonolito.DTO;

namespace HackathonMonolito.Services.Interfaces;

public interface ISimulacaoService
{
    Task<SimulacaoResponseDTO?> RealizarSimulacaoAsync(SimulacaoRequestDTO request, CancellationToken ct);
}