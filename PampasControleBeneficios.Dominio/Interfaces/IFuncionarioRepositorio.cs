using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Dominio.Interfaces;

public interface IFuncionarioRepositorio
{
    Task<Funcionario?> ObterPorIdAsync(int id);

    Task<IEnumerable<Funcionario>> ListarAsync();

    Task<int> CadastrarAsync(Funcionario funcionario);

    Task AtualizarAsync(Funcionario funcionario);
}