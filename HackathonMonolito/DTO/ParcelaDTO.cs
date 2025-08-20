using System.Text.Json.Serialization;
using HackathonMonolito.Models.Enums;

namespace HackathonMonolito.DTO;

public class ParcelaDTO
{
    [JsonPropertyName("numero")]
    public int Numero { get; set; }   
    [JsonPropertyName("valorAmortizacao")]
    public decimal ValorAmortizacao { get; set; }
    [JsonPropertyName("valorJuros")]    
    public decimal ValorJuros { get; set; }
    [JsonPropertyName("valorPrestacao")]
    public decimal ValorPrestacao { get; set; }
    
}