namespace HackathonMonolito.DTO;

public class SimulacaoListRequest : PagedRequest
{
    public int? CodigoProduto { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
}
