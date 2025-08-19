using HackathonMonolito.Models;

namespace HackathonMonolito.DTO;

public class SimulacaoResponseDTO
{
    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; }
    public decimal TaxaJuros { get; set; }
    
    public List<ResultadoSimulacao> ResultadoSimulacao { get; set; }
}