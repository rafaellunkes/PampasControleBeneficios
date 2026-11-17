
using System.Data;
using Dapper;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.RowModels;

namespace PampasControleBeneficios.Infra.Data.Repositorios;

public class FuncionarioBeneficioRepositorio(IDbConnection connection) : IFuncionarioBeneficioRepositorio
{
    private const string SelectColunas = @"
        SELECT 
            ID_FUNCIONARIO_BENEFICIO, 
            ID_FUNCIONARIO, 
            ID_BENEFICIO
        FROM FUNCIONARIO_BENEFICIO";

    public Task<int> CadastrarAsync(int idFuncionario, int idBeneficio)
    {
        var id = connection.ExecuteScalarAsync<int>(@"
        INSERT INTO FUNCIONARIO_BENEFICIO (ID_FUNCIONARIO, ID_BENEFICIO)
        VALUES(@IdFuncionario, @IdBeneficio)
        RETURNING ID_FUNCIONARIO_BENEFICIO", new { IdFuncionario = idFuncionario, IdBeneficio = idBeneficio });

        return id;
    }

    public async Task<IEnumerable<int>> ListarIdBeneficioPorIdFuncionarioAsync(int idFuncionario)
    {
        var listaDeIdBeneficio = await connection.QueryAsync<int>(@$"SELECT ID_BENEFICIO FROM FUNCIONARIO_BENEFICIO WHERE ID_FUNCIONARIO = @IdFuncionario", new { IdFuncionario = idFuncionario });

        return listaDeIdBeneficio;
    }

    public async Task<FuncionarioBeneficio?> ObterPorIdAsync(int id)
    {
        var result = await connection.QueryFirstOrDefaultAsync<FuncionarioBeneficioRow>(@$"{SelectColunas} WHERE ID_FUNCIONARIO_BENEFICIO = @Id", new { Id = id });

        return result?.ToEntity();
    }

    public async Task<FuncionarioBeneficio?> ObterPorIdFuncionarioAsync(int idFuncionario)
    {
        var result = await connection.QueryFirstOrDefaultAsync<FuncionarioBeneficioRow>(@$"{SelectColunas} WHERE ID_FUNCIONARIO = @IdFuncionario", new { IdFuncionario = idFuncionario });

        return result?.ToEntity();
    }
}