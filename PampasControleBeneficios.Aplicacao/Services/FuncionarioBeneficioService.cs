using PampasControleBeneficios.Aplicacao.Dto.Beneficios;
using PampasControleBeneficios.Dominio.Interfaces;

namespace PampasControleBeneficios.Aplicacao.Services;

public class FuncionarioBeneficioService(IFuncionarioBeneficioRepositorio funcionarioBeneficioRepositorio, IBeneficioRepositorio beneficioRepositorio)
{
    public async Task VincularBeneficioFuncionarioAsync(int idFuncionario, int idBeneficio)
    {
        await funcionarioBeneficioRepositorio.CadastrarAsync(idFuncionario, idBeneficio);
    }

    public async Task<IEnumerable<BeneficioDto>> ListarBeneficiosPorFuncionarioAsync(int idFuncionario)
    {
        var idsBeneficios = await funcionarioBeneficioRepositorio.ListarIdBeneficioPorIdFuncionarioAsync(idFuncionario);

        var beneficios = await beneficioRepositorio.ListarPorIdsAsync(idsBeneficios);

        return beneficios.Select(b => (BeneficioDto)b);
    }
    
}