using HackathonMonolito.Models;
using HackathonMonolito.Models.Enums;

namespace HackathonMonolito.Repositories.Interfaces;

public interface ICalculadoraAmortizacao
{
    SistemaAmortizacao Tipo { get; }
    ResultadoSimulacao Calcular(decimal valorPrincipal, decimal taxaMensal, int prazo);
}