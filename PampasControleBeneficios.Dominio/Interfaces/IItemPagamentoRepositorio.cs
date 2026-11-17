using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Dominio.Interfaces;

public interface IItemPagamentoRepositorio
{
    Task Cadastrar(int idPagamento, IEnumerable<ItemPagamento> itensPagamento);

    Task<ItemPagamento?> ObterPorIdAsync(int id);

    Task<ItemPagamento?> ObterPorIdPagamentoAsync(int id);

    Task<IEnumerable<ItemPagamento>> ListarAsync();
}