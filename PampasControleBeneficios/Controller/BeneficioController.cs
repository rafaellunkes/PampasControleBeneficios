using Microsoft.AspNetCore.Mvc;
using PampasControleBeneficios.Aplicacao.Dto.Beneficios;
using PampasControleBeneficios.Aplicacao.Services;

namespace PampasControleBeneficios.Controller;

[ApiController]
[Route("api/[controller]")]
public class BeneficioController : ControllerBase
{
    private readonly BeneficioService beneficioService;

    public BeneficioController(BeneficioService beneficioService)
    {
        this.beneficioService = beneficioService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarAsync([FromBody] CriarBeneficioDto dto)
    {
        await beneficioService.CadastrarAsync(dto);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
        var result = await beneficioService.ObterPorIdAsync(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}