using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace HackathonMonolito.DTO;

public class SimulacaoRequestDTO
{

    [SwaggerSchema(Description = "Valor desejado do empréstimo")]
    [DefaultValue(900.00)]
    [System.Text.Json.Serialization.JsonPropertyName("valorDesejado")]
    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, 9999999999999999.99, ErrorMessage = "Valor deve estar entre 0.01 e 9999999999999999.99")]
    [RegularExpression(@"^\d{1,16}([.,]\d{1,2})?$",
        ErrorMessage = "Valor deve ter no máximo 16 dígitos antes da vírgula e até 2 após")]
    public decimal Valor { get; set; }

    [SwaggerSchema(Description = "Prazo em meses")]
    [DefaultValue(5)]
    [System.Text.Json.Serialization.JsonPropertyName("prazo")]
    [Required(ErrorMessage = "Prazo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Prazo deve ser maior que zero")]
    public int Prazo { get; set; } 
}