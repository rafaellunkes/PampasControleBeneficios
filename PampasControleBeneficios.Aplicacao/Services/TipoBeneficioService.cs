using PampasControleBeneficios.Aplicacao.Dto.TiposBeneficio;
using PampasControleBeneficios.Dominio.Interfaces;

namespace PampasControleBeneficios.Aplicacao.Services;

public class TipoBeneficioService(ITipoBeneficioRepositorio tipoBeneficioRepositorio)
{
    public async Task<IEnumerable<TipoBeneficioDto>> ListarAsync()
    {
        var result = await tipoBeneficioRepositorio.ListarAsync();

        return result.Select(r => (TipoBeneficioDto)r);
    }

    public async Task<TipoBeneficioDto?> ObterPorIdAsync(int id)
    {
        var result = await tipoBeneficioRepositorio.ObterPorIdAsync(id);

        if (result is null)
        {
            return null;
        }

        return (TipoBeneficioDto)result;
    }
}