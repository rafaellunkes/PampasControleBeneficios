using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Dominio.Interfaces;

public interface IPagamentoRepositorio
{
    Task<Pagamento?> ObterPorIdAsync(int id);

    Task<IEnumerable<Pagamento>> ListarAsync();

    Task<int> Cadastrar(Pagamento Pagamento);
}