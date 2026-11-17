using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Dominio.Interfaces;

public interface IFuncionarioBeneficioRepositorio
{
    Task<FuncionarioBeneficio?> ObterPorIdAsync(int id);

    Task<FuncionarioBeneficio?> ObterPorIdFuncionarioAsync(int idFuncionario);

    Task<IEnumerable<int>> ListarIdBeneficioPorIdFuncionarioAsync(int idFuncionario);

    Task<int> CadastrarAsync(int idFuncionario, int idBeneficio);
}