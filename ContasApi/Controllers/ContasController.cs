using ContasLib.Models;
using ContasBusiness;
using Microsoft.AspNetCore.Mvc;

namespace ContasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController(ContaService contaService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var contas = contaService.ListarTodas();
        return contas.Count == 0 ? NoContent() : Ok(contas);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var conta = contaService.ObterPorId(id);
        return conta == null ? NotFound() : Ok(conta);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Conta conta)
    {
        if (string.IsNullOrWhiteSpace(conta.Titular) || string.IsNullOrWhiteSpace(conta.Numero))
            return BadRequest("Titular e número da conta são obrigatórios.");
        var criada = contaService.Criar(conta);
        return CreatedAtAction(nameof(Get), new { id = criada.Id }, criada);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Conta conta)
    {
        if (conta == null || conta.Id != id)
            return BadRequest("Dados inconsistentes.");
        return contaService.Atualizar(conta) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return contaService.Remover(id) ? NoContent() : NotFound();
    }
}
