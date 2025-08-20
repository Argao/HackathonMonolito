using HackathonMonolito.Configuration;
using HackathonMonolito.DTO;
using HackathonMonolito.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonMonolito.Repositories;

public class SimulacaoRepository(AppDbContext context) : ISimulacaoRepository
{
    
    public async Task<Simulacao> AdicionarAsync(Simulacao simulacao, CancellationToken ct)
    {
        context.Simulacoes.Add(simulacao);
        await context.SaveChangesAsync(ct);
        return simulacao;
    }

    public async Task<PagedResponse<Simulacao>> ListarPaginadoAsync(PagedRequest request, CancellationToken ct)
    {
        var query = context.Simulacoes
            .Include(s => s.Resultados) // Carrega os resultados relacionados
            .AsQueryable();
        
        // Ordenação para consistência na paginação
        query = query.OrderByDescending(s => s.DataReferencia)
            .ThenByDescending(s => s.IdSimulacao);

        return await query.ToPaginatedListAsync(
            request.GetValidPageNumber(), 
            request.GetValidPageSize(), 
            ct);
    }

}