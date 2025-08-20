using HackathonMonolito.Models;
using HackathonMonolito.Models.Enums;
using HackathonMonolito.Repositories.Interfaces;

namespace HackathonMonolito.Services;

public class CalculadoraPRICE : ICalculadoraAmortizacao
{
    public SistemaAmortizacao Tipo => SistemaAmortizacao.PRICE;
    
    public ResultadoSimulacao Calcular(decimal valorPrincipal, decimal taxaMensal, int prazo)
    {
        var resultado = new ResultadoSimulacao
        {
            Tipo = Tipo
        };

        var debitoAtual = valorPrincipal;
        
        for (var i = 1; i <= prazo; i++)
        {
            var valorParcela = CalcularParcela(debitoAtual, taxaMensal, prazo - i + 1);
            var juros = Math.Round(debitoAtual * taxaMensal, 2);
            var amortizacao = valorParcela - juros;
            
            resultado.Parcelas.Add(new Parcela
            {
                IdResultado = resultado.IdResultado,
                Numero = i,
                ValorPrestacao = valorParcela,
                ValorAmortizacao = amortizacao,
                ValorJuros = juros
            });
            debitoAtual -= amortizacao;
        }

        return resultado;
    }

    private decimal CalcularParcela(decimal debitoAtual, decimal taxaMensal, int numParcela)
    {
        var fator = (decimal)Math.Pow((double)(1 + taxaMensal), -numParcela);
        return Math.Round(debitoAtual * taxaMensal / (1 - fator),2);
    }
}