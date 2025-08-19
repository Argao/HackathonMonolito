using HackathonMonolito.DTO;
using HackathonMonolito.Models;
using HackathonMonolito.Repositories;
using HackathonMonolito.Repositories.Interfaces;

namespace HackathonMonolito.Services;

public class SimulacaoService
{
    private readonly ISimulacaoRepository _simulacaoRepository;
    private readonly IProdutoRepository _produtoRepository;

    public SimulacaoService(IProdutoRepository produtoRepository, ISimulacaoRepository simulacaoRepository)
    {
        _produtoRepository = produtoRepository;
        _simulacaoRepository = simulacaoRepository;
    }


    // public async Task<Simulacao?> RealizarSimulacao(decimal valorDesejado, short prazo, CancellationToken ct)
    // {
    //     var produto = await GetProdutoAdequadoAsync(valorDesejado, prazo, ct);
    //     if (produto is null) return null;
    //     var simulacao = new Simulacao();
    //     simulacao.CodigoProduto = produto.Codigo;
    //     simulacao.DescricaoProduto = produto.Descricao;
    //     simulacao.TaxaJuros = produto.TaxaMensal;
    //     simulacao.PrazoMeses = prazo;
    //     simulacao.ValorDesejado = valorDesejado;
    //
    //
    //
    // }
    

    private async Task<Produto?> GetProdutoAdequadoAsync(decimal valor, int prazo, CancellationToken ct)
    {
        return await _produtoRepository.GetProdutoAdequadoAsync(valor, prazo, ct);
    }
}