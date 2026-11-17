using System.Data;
using Dapper;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.RowModels;

namespace PampasControleBeneficios.Infra.Data.Repositorios;

public class PagamentoRepositorio(IDbConnection connection) : IPagamentoRepositorio
{
    private const string SelectColunas = @"
        SELECT 
            ID_PAGAMENTO,
            ID_FUNCIONARIO,
            COMPETENCIA,
            VALOR_TOTAL,
            PAGO,
            DATA_PAGAMENTO
        FROM PAGAMENTO";

    public async Task<int> Cadastrar(Pagamento pagamento)
    {
        var id = await connection.ExecuteScalarAsync<int>(@"
        INSERT INTO FUNCIONARIO (
            ID_FUNCIONARIO,
            COMPETENCIA,
            VALOR_TOTAL,
            PAGO,
            DATA_PAGAMENTO )
        VALUES(
        @IdFuncionario, @ValorTotal, @Pago, @DataPagamento
        )
        RETURNING ID_PAGAMENTO
        ", new
        {
            pagamento.IdFuncionario,
            pagamento.Competencia,
            pagamento.ValorTotal,
            pagamento.Pago,
            pagamento.DataPagamento
        });

        return id;
    }

    public async Task<IEnumerable<Pagamento>> ListarAsync()
    {
        var lista = await connection.QueryAsync<PagamentoRow>(@$"{SelectColunas}");

        return lista.Select(f => f.ToEntity());
    }

    public async Task<Pagamento?> ObterPorIdAsync(int id)
    {
        var pagamento = await connection.QueryFirstOrDefaultAsync<PagamentoRow>(@$"{SelectColunas} WHERE ID_PAGAMENTO = @Id ", new { Id = id });

        return pagamento?.ToEntity();
    }
}