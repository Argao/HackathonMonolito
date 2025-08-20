using HackathonMonolito.Models;
using HackathonMonolito.Models.Enums;
using HackathonMonolito.Repositories.Interfaces;

namespace HackathonMonolito.Services;

public class CalculadoraSAC : ICalculadoraAmortizacao
{
    public SistemaAmortizacao Tipo => SistemaAmortizacao.SAC;
    
    public ResultadoSimulacao Calcular(decimal valorPrincipal, decimal taxaMensal, int prazo)
    {
        var resultado = new ResultadoSimulacao
        {
            Tipo = Tipo
        };


        var saldoDevedor = valorPrincipal;
        
        for (int i = 1; i <= prazo; i++)
        {
            var valorAmortizacao = Math.Round(saldoDevedor/(prazo -i + 1) , 2);
            var juros = decimal.Round(saldoDevedor * taxaMensal, 2);
            var valorParcela = valorAmortizacao + juros;
            
            resultado.Parcelas.Add(new Parcela
            {
                IdResultado = resultado.IdResultado,
                Numero = i,
                ValorPrestacao = Math.Round(valorParcela,2),
                ValorAmortizacao = valorAmortizacao,
                ValorJuros = juros
            });
            saldoDevedor -= valorAmortizacao;
        }

        return resultado;
    }
}