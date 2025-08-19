using HackathonMonolito.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HackathonMonolito.Controllers;

[ApiController]
[Route("simulacao")]
public class SimulacaoController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<SimulacaoResponseDTO>> RealizarSimulacao([FromBody] decimal valorDesejado, [FromBody] short prazo)
    {
        await Task.CompletedTask;
        return Ok();
    }
}