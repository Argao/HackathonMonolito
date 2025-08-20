using HackathonMonolito.DTO;
using HackathonMonolito.Models;
using HackathonMonolito.Repositories;
using HackathonMonolito.Repositories.Interfaces;
using HackathonMonolito.Services.Interfaces;

namespace HackathonMonolito.Services;

public class SimulacaoService : ISimulacaoService
{
    private readonly ISimulacaoRepository _simulacaoRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEnumerable<ICalculadoraAmortizacao> _calculadoras;

    public SimulacaoService(IProdutoRepository produtoRepository, ISimulacaoRepository simulacaoRepository, IEnumerable<ICalculadoraAmortizacao> calculadoras)
    {
        _produtoRepository = produtoRepository;
        _simulacaoRepository = simulacaoRepository;
        _calculadoras = calculadoras;
    }


    public async Task<SimulacaoResponseDTO?> RealizarSimulacaoAsync(SimulacaoRequestDTO request, CancellationToken ct)
    {
        var produto = await _produtoRepository.GetProdutoAdequadoAsync(request.Valor,request.Prazo, ct);
        if (produto is null) return null;
        
        var simulacao = CriarSimulacao(request, produto);
        
        var resultados = _calculadoras.Select(c => c.Calcular(request.Valor, produto.TaxaMensal, request.Prazo));
        simulacao.Resultados = resultados.ToList();
        
        await _simulacaoRepository.AdicionarAsync(simulacao, ct);

        return CriarResponseDto(simulacao);
    }
    
    private static Simulacao CriarSimulacao(SimulacaoRequestDTO request, Produto produto)
    {
        return new Simulacao
        {
            CodigoProduto = produto.Codigo,
            DescricaoProduto = produto.Descricao,
            TaxaJuros = produto.TaxaMensal,
            PrazoMeses = (short)request.Prazo,
            ValorDesejado = request.Valor,
            DataReferencia = DateOnly.FromDateTime(DateTime.Today)
        };
    }
    private static SimulacaoResponseDTO CriarResponseDto(Simulacao simulacao)
    {
        return new SimulacaoResponseDTO
        {
            Id = simulacao.IdSimulacao,
            CodigoProduto = simulacao.CodigoProduto,
            DescricaoProduto = simulacao.DescricaoProduto,
            TaxaJuros = simulacao.TaxaJuros,
            ResultadoSimulacao = simulacao.Resultados.Select(r => new ResultadoSimulacaoDTO
            {
                Tipo = r.Tipo,
                Parcelas = r.Parcelas.Select(p => new ParcelaDTO
                {
                    Numero = p.Numero,
                    ValorAmortizacao = p.ValorAmortizacao,
                    ValorJuros = p.ValorJuros,
                    ValorPrestacao = p.ValorPrestacao
                }).ToList()
            }).ToList()
        };
    }
    


}