using Microsoft.AspNetCore.Mvc;
using PampasControleBeneficios.Aplicacao.Services;

namespace PampasControleBeneficios.Controller;

[ApiController]
[Route("api/[controller]")]
public class TipoBeneficioController(TipoBeneficioService tipoBeneficioService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> ListarAsync()
    {
        var listaTipoBeneficio = await tipoBeneficioService.ListarAsync();
        return Ok(listaTipoBeneficio);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
        var result = await tipoBeneficioService.ObterPorIdAsync(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}