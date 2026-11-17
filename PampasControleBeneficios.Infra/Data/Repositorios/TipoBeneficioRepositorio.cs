using System.Data;
using Dapper;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.RowModels;

namespace PampasControleBeneficios.Infra.Data.Repositorios;

public class TipoBeneficioRepositorio(IDbConnection connection) : ITipoBeneficioRepositorio
{
    private const string SelectTipoBeneficioQuery = @"
        SELECT 
            ID_TIPO_BENEFICIO,
            NOME,
            PERMITE_MULTIPLAS_LINHAS,
            MULTIPLICADOR_DIARIO
        FROM TIPO_BENEFICIO";
    public async Task<TipoBeneficio?> ObterPorIdAsync(int id)
    {
        var tipoBeneficio = await connection.QueryFirstOrDefaultAsync<TipoBeneficioRow>(@$"
        {SelectTipoBeneficioQuery} WHERE ID_TIPO_BENEFICIO = @Id", new { Id = id });

        return tipoBeneficio?.ToEntity();
    }

    public async Task<IEnumerable<TipoBeneficio>> ListarAsync()
    {
        var tiposBeneficio = await connection.QueryAsync<TipoBeneficioRow>(@$"
        {SelectTipoBeneficioQuery}");

        return tiposBeneficio.Select(t => t.ToEntity());
    }
}