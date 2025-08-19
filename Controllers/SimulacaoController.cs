using HackathonMonolito.DTO;
using HackathonMonolito.Models;
using HackathonMonolito.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackathonMonolito.Controllers;

[ApiController]
[Route("simulacao")]
public class SimulacaoController(IProdutoRepository produtoRepository)  : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Produto?>> RealizarSimulacao(SimulacaoRequestDTO request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var p = await produtoRepository.GetProdutoAdequadoAsync(request.Valor, request.Prazo, ct);
        if (p is null) return NotFound("Nenhum produto atende aos parâmetros.");
        return Ok(p);
    }

}