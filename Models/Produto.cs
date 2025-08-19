namespace HackathonMonolito.Models;

public sealed record Produto
{
    public int Codigo { get; init; }
    public string Descricao { get; init; }
    public decimal TaxaMensal { get; init; }
    public short MinMeses { get; init; }
    public short? MaxMeses { get; init; }
    public decimal MinValor { get; init; }
    public decimal? MaxValor { get; init; }
}