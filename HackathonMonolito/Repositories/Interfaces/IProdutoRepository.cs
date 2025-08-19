using HackathonMonolito.Models;

namespace HackathonMonolito.Repositories.Interfaces;

public interface IProdutoRepository
{
    Task<Produto?> GetProdutoAdequadoAsync(decimal valor, int prazo, CancellationToken ct);
}