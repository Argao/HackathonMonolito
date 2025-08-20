using System.Collections;
using System.Text.Json.Serialization;
using HackathonMonolito.Models.Enums;

namespace HackathonMonolito.DTO;

public class ListarSimulacoesDTO
{
    [JsonPropertyName("idSimulacao")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("valorDesejado")]
    public decimal ValorDesejado { get; set; }
    
    [JsonPropertyName("prazo")]
    public short PrazoMeses { get; set; }
    
    [JsonPropertyName("valorTotalParcelas")]
    public ICollection<ValorTotalParcelasDTO> ResultadoSimulacao { get; set; }
    
}

public class ValorTotalParcelasDTO()
{
    [JsonPropertyName("tipo")]
    public SistemaAmortizacao Tipo { get; set; }
    [JsonPropertyName("valor")]   
    public decimal ValorTotal { get; set; }
}