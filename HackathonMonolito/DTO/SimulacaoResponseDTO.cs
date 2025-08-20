using System.Text.Json.Serialization;
using HackathonMonolito.Models;

namespace HackathonMonolito.DTO;

public class SimulacaoResponseDTO
{
    [JsonPropertyName("idSimulacao")]
    public Guid Id { get; set; }
    [JsonPropertyName("codigoProduto")]
    public int CodigoProduto { get; set; }
    [JsonPropertyName("descricaoProduto")]
    public string DescricaoProduto { get; set; }
    
    [JsonPropertyName("taxaJuros")]
    public decimal TaxaJuros { get; set; }
    
    [JsonPropertyName("resultadoSimulacao")]
    public ICollection<ResultadoSimulacaoDTO> ResultadoSimulacao { get; set; }
}