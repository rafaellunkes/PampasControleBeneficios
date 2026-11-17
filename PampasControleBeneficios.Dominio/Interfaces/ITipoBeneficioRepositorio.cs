using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Dominio.Interfaces;

public interface ITipoBeneficioRepositorio
{
    Task<TipoBeneficio?> ObterPorIdAsync(int id);

    Task<IEnumerable<TipoBeneficio>> ListarAsync();
}