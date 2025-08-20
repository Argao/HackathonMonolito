using System.Text.Json.Serialization;
using HackathonMonolito.Models.Enums;

namespace HackathonMonolito.DTO;

public class ResultadoSimulacaoDTO
{
    [JsonPropertyName("tipo")]
    public SistemaAmortizacao Tipo { get; set; }
    
    [JsonPropertyName("parcelas")]
    public ICollection<ParcelaDTO> Parcelas { get; set; }
}