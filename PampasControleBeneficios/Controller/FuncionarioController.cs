using Microsoft.AspNetCore.Mvc;
using PampasControleBeneficios.Aplicacao.Dto.Funcionarios;
using PampasControleBeneficios.Aplicacao.Services;

namespace PampasControleBeneficios.Controller;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController(FuncionarioService funcionarioService) : ControllerBase
{
    private readonly FuncionarioService funcionarioService = funcionarioService;

    [HttpPost]
    public async Task<IActionResult> CadastrarAsync([FromBody] CriarFuncionarioDto dto)
    {
        await funcionarioService.CadastrarAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarFuncionarioDto dto)
    {
        await funcionarioService.AtualizarAsync(dto);
        return Ok();
    }

    [HttpPatch("inativar/{id}")]
    public async Task<IActionResult> InativarAsync(int id)
    {
        await funcionarioService.InativarAsync(id);
        return Ok();
    }

    [HttpPatch("ativar/{id}")]
    public async Task<IActionResult> AtivarAsync(int id)
    {
        await funcionarioService.AtivarAsync(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ListarAsync()
    {
        var result = await funcionarioService.ListarAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
        var result = await funcionarioService.ObterPorIdAsync(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}