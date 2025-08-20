using HackathonMonolito.Models;
using HackathonMonolito.Models.Enums;
using HackathonMonolito.Repositories.Interfaces;

namespace HackathonMonolito.Services;

public class CalculadoraPRICE : ICalculadoraAmortizacao
{
    public SistemaAmortizacao Tipo => SistemaAmortizacao.PRICE;
    
    public ResultadoSimulacao Calcular(decimal valorPrincipal, decimal taxaMensal, int prazo)
    {
        // calcula a prestação fixa usando o saldo original e o prazo total
        decimal fator = (decimal)Math.Pow((double)(1 + taxaMensal), prazo);
        decimal valorParcela = decimal.Round(
            valorPrincipal * taxaMensal * fator / (fator - 1),
            2,
            MidpointRounding.AwayFromZero);

        var resultado = new ResultadoSimulacao { Tipo = SistemaAmortizacao.PRICE };
        decimal saldoDevedor = valorPrincipal;

        for (int parcela = 1; parcela <= prazo; parcela++)
        {
            // juros do mês com arredondamento financeiro
            decimal juros = decimal.Round(saldoDevedor * taxaMensal, 2, MidpointRounding.AwayFromZero);
            // amortização é a diferença entre a prestação e os juros
            decimal amortizacao = decimal.Round(valorParcela - juros, 2, MidpointRounding.AwayFromZero);
            // atualiza o saldo devedor mantendo mais casas decimais para evitar erros acumulados
            saldoDevedor = decimal.Round(saldoDevedor - amortizacao, 2, MidpointRounding.AwayFromZero);

            resultado.Parcelas.Add(new Parcela
            {
                Numero = parcela,
                ValorPrestacao = valorParcela,
                ValorAmortizacao = amortizacao,
                ValorJuros = juros,
            });
        }
        return resultado;
    }

}