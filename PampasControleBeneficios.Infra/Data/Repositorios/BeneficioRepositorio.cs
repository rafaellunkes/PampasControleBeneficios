using System.Data;
using Dapper;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.RowModels;

namespace PampasControleBeneficios.Infra.Data.Repositorios;

public class BeneficioRepositorio(IDbConnection connection) : IBeneficioRepositorio
{
    private const string SelectBeneficioQuery = @"
        SELECT 
            ID_BENEFICIO,
            ID_TIPO_BENEFICIO, 
            NOME, 
            VALOR_DIARIO, 
            ATIVO FROM BENEFICIO";
    public async Task<int> CadastrarAsync(int idTipoBeneficio, string nome, decimal valorDiario)
    {
        return await connection.ExecuteScalarAsync<int>(@"
        INSERT INTO BENEFICIO (
            ID_TIPO_BENEFICIO, 
            NOME, 
            VALOR_DIARIO) 
        VALUES (
        @IdTipoBeneficio,
        @Nome,
        @ValorDiario
        )
        RETURNING ID_BENEFICIO", new
        {
            IdTipoBeneficio = idTipoBeneficio,
            Nome = nome,
            ValorDiario = valorDiario
        });
    }

    public Task<IEnumerable<Beneficio>> ListarPorIdsAsync(IEnumerable<int> ids)
    {
        var beneficios = connection.QueryAsync<BeneficioRow>(@$"
        {SelectBeneficioQuery} WHERE ID_BENEFICIO IN (@Ids)", new { Ids = ids });

        return beneficios.ContinueWith(t => t.Result.Select(b => b.ToEntity()));
    }

    public async Task<Beneficio?> ObterPorIdAsync(int id)
    {
        var beneficio = await connection.QueryFirstOrDefaultAsync<BeneficioRow>(@$"
        {SelectBeneficioQuery} WHERE ID_BENEFICIO = @Id", new { Id = id });

        return beneficio?.ToEntity();
    }
}