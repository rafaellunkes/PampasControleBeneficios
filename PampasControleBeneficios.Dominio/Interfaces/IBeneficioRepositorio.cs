using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Dominio.Interfaces;

public interface IBeneficioRepositorio
{
    Task<Beneficio?> ObterPorIdAsync(int id);

    Task<IEnumerable<Beneficio>> ListarPorIdsAsync(IEnumerable<int> ids);

    Task<int> CadastrarAsync(int idTipoBeneficio, string nome, decimal valorDiario);
}