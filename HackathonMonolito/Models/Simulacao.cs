using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HackathonMonolito.Models.Enums;

namespace HackathonMonolito.Models;

[Table("SIMULACAO")]
public sealed class Simulacao
{
    public Guid IdSimulacao { get; set; } = Guid.NewGuid();
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = string.Empty;
    public decimal TaxaJuros { get; set; }
    public decimal ValorDesejado { get; set; }
    public short PrazoMeses { get; set; }
    public DateOnly DataReferencia { get; set; }

    public string EnvelopJson { get; set; } = string.Empty;
    public ICollection<ResultadoSimulacao> Resultados { get; set; } = new List<ResultadoSimulacao>();
    
}