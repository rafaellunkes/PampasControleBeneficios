using System.Data;
using Dapper;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;
using PampasControleBeneficios.Infra.Data.RowModels;

namespace PampasControleBeneficios.Infra.Data.Repositorios; 

public class FuncionarioRepositorio(IDbConnection connection) : IFuncionarioRepositorio
{
    private const string SelectColunas = @"
        SELECT 
            ID_FUNCIONARIO, 
            NOME, 
            CPF, 
            TELEFONE, 
            ENDERECO, 
            ATIVO
        FROM FUNCIONARIO";

    public async Task AtualizarAsync(Funcionario funcionario)
    {
        await connection.ExecuteAsync(@"
        UPDATE FUNCIONARIO
        SET 
            NOME = @Nome,
            CPF = @Cpf,
            TELEFONE = @Telefone,
            ENDERECO = @Endereco,
            ATIVO = @Ativo
        WHERE ID_FUNCIONARIO = @Id
        ", funcionario);
    }

    public async Task<int> CadastrarAsync(Funcionario funcionario)
    {
        var id = await connection.ExecuteScalarAsync<int>(@"
        INSERT INTO FUNCIONARIO (NOME, CPF, TELEFONE, ENDERECO, ATIVO)
        VALUES(
        @Nome, @Cpf, @Telefone, @Endereco, @Ativo
        )
        RETURNING ID_FUNCIONARIO
        ", new
        {
            funcionario.Nome,
            funcionario.Cpf,
            funcionario.Telefone,
            funcionario.Endereco,
            funcionario.Ativo
        });

        return id;
    }

    public async Task<IEnumerable<Funcionario>> ListarAsync()
    {
        var lista = await connection.QueryAsync<FuncionarioRow>(@$"{SelectColunas}");

        return lista.Select(f => f.ToEntity());
    }

    public async Task<Funcionario?> ObterPorIdAsync(int id)
    {
        var funcionario = await connection.QueryFirstOrDefaultAsync<FuncionarioRow>(@$"{SelectColunas} WHERE ID_FUNCIONARIO = @Id ", new { Id = id });

        return funcionario?.ToEntity();
    }
}