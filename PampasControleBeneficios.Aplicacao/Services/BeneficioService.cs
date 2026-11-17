using PampasControleBeneficios.Aplicacao.Dto.Beneficios;
using PampasControleBeneficios.Dominio.Interfaces;

namespace PampasControleBeneficios.Aplicacao.Services;

public class BeneficioService(IBeneficioRepositorio beneficioRepositorio)
{
    public async Task CadastrarAsync(CriarBeneficioDto dto)
    {
        await beneficioRepositorio.CadastrarAsync(dto.IdTipoBeneficio, dto.Nome, dto.ValorDiario);
    }

    public async Task<BeneficioDto?> ObterPorIdAsync(int id)
    {
        var result = await beneficioRepositorio.ObterPorIdAsync(id);

        if (result is null)
        {
            return null;
        }

        return (BeneficioDto)result;
    }
}