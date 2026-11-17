using System.Data;
using Dapper;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.RowModels;

namespace PampasControleBeneficios.Infra.Data.Repositorios;

public class ItemPagamentoRepositorio(IDbConnection connection) : IItemPagamentoRepositorio
{
    private const string SelectColunas = @"
    SELECT 
        ID_ITEM_PAGAMENTO,
        ID_PAGAMENTO,
        ID_TIPO_BENEFICIO,
        DIAS_TRABALHADOS,
        VALOR_DIARIO,
        SUB_TOTAL
    FROM ITEM_PAGAMENTO";
    public async Task Cadastrar(int idPagamento, IEnumerable<ItemPagamento> itensPagamento)
    {

        var parametros = itensPagamento.Select(i => new
        {
            IdPagamento = idPagamento,
            i.IdTipoBeneficio,
            i.DiasTrabalhados,
            i.ValorDiario,
            i.SubTotal
        }).ToList();

        if (parametros.Count == 0)
            return;

        await connection.ExecuteAsync(@"
        INSERT INTO ITEM_PAGAMENTO (
            ID_PAGAMENTO,
            ID_TIPO_BENEFICIO,
            DIAS_TRABALHADOS,
            VALOR_DIARIO,
            SUB_TOTAL)
        VALUES (
            @IdPagamento,
            @IdTipoBeneficio,
            @DiasTrabalhados,
            @ValorDiario,
            @SubTotal
        )", new
        {
            parametros
        });
    }

    public async Task Atualizar(ItemPagamento itemPagamento)
    {
        await connection.ExecuteAsync(@"
        UPDATE ITEM_PAGAMENTO
        SET 
            ID_PAGAMENTO = @IdPagamento,
            ID_TIPO_BENEFICIO = @IdTipoBeneficio,
            DIAS_TRABALHADOS = @DiasTrabalhados,
            VALOR_DIARIO = @ValorDiario,
            SUB_TOTAL = @SubTotal
        WHERE ID_ITEM_PAGAMENTO = @Id
        ", itemPagamento);
    }

    public async Task<ItemPagamento?> ObterPorIdAsync(int id)
    {
        var ItemPagamento = await connection.QueryFirstOrDefaultAsync<ItemPagamentoRow>($@"{SelectColunas} WHERE ID_ITEM_PAGAMENTO = @Id ", new { Id = id });

        return ItemPagamento?.ToEntity();
    }

    public async Task<ItemPagamento?> ObterPorIdPagamentoAsync(int id)
    {
        var ItemPagamento = await connection.QueryFirstOrDefaultAsync<ItemPagamentoRow>($@"{SelectColunas} WHERE ID_PAGAMENTO = @Id ", new { Id = id });

        return ItemPagamento?.ToEntity();
    }

    public async Task<IEnumerable<ItemPagamento>> ListarAsync()
    {
        var lista = await connection.QueryAsync<ItemPagamentoRow>(@$"{SelectColunas}");

        return lista.Select(f => f.ToEntity());
    }
}