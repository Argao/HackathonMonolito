using HackathonMonolito.Models;
using HackathonMonolito.Models.Enums;
using HackathonMonolito.Repositories.Interfaces;

namespace HackathonMonolito.Services;

public class CalculadoraSAC : ICalculadoraAmortizacao
{
    public SistemaAmortizacao Tipo => SistemaAmortizacao.SAC;
    public ResultadoSimulacao Calcular(decimal valorPrincipal, decimal taxaMensal, int prazo)
    {
        var resultado = new ResultadoSimulacao { Tipo = SistemaAmortizacao.SAC };
        decimal saldoDevedor = valorPrincipal;
        // amortização constante: divide o saldo inicial pelo número de parcelas
        decimal amortizacaoConstante = decimal.Round(
            valorPrincipal / prazo,
            2,
            MidpointRounding.AwayFromZero);

        for (int parcela = 1; parcela <= prazo; parcela++)
        {
            // juros do mês
            decimal juros = decimal.Round(saldoDevedor * taxaMensal, 2, MidpointRounding.AwayFromZero);
            // valor da prestação varia: amortização constante + juros
            decimal valorPrestacao = decimal.Round(amortizacaoConstante + juros, 2, MidpointRounding.AwayFromZero);
            // diminui o saldo devedor apenas pela amortização
            saldoDevedor = decimal.Round(saldoDevedor - amortizacaoConstante, 2, MidpointRounding.AwayFromZero);

            resultado.Parcelas.Add(new Parcela
            {
                Numero = parcela,
                ValorPrestacao = valorPrestacao,
                ValorAmortizacao = amortizacaoConstante,
                ValorJuros = juros,
            });
        }
        return resultado;
    }
}