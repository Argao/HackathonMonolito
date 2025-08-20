using HackathonMonolito.DTO;
using HackathonMonolito.Models;
using HackathonMonolito.Repositories.Interfaces;
using HackathonMonolito.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackathonMonolito.Controllers;

[ApiController]
[Route("simulacao")]
public class SimulacaoController(ISimulacaoService simulacaoService)  : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<SimulacaoResponseDTO>> RealizarSimulacao(SimulacaoRequestDTO request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await simulacaoService.RealizarSimulacaoAsync(request, ct);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<ListarSimulacoesDTO>>> ListarSimulacoes(
        [FromQuery] PagedRequest request, 
        CancellationToken ct)
    {
        var response = await simulacaoService.ListarPaginadoAsync(request, ct);
        return Ok(response);
    }


}