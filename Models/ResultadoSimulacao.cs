using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HackathonMonolito.Models.Enums;

namespace HackathonMonolito.Models;

[Table("RESULTADO_SIMULACAO")]
public class ResultadoSimulacao
{
    public Guid IdResultado { get; set; } = Guid.NewGuid();
    public Guid IdSimulacao { get; set; }
    public SistemaAmortizacao Tipo { get; set; }
    public Simulacao Simulacao { get; set; } = null!;
    public ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();
}