using PampasControleBeneficios.Aplicacao.Dto.Funcionarios;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;

namespace PampasControleBeneficios.Aplicacao.Services;

public class FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio)
{
    public async Task CadastrarAsync(CriarFuncionarioDto dto)
    {
        var funcionario = Funcionario.Criar(dto.Nome, dto.Cpf, dto.Telefone, dto.Endereco);
        _ = await funcionarioRepositorio.CadastrarAsync(funcionario);
    }

    public async Task InativarAsync(int id)
    {
        var funcionario = await funcionarioRepositorio.ObterPorIdAsync(id) ?? throw new Exception("Funcionário não encontrado");

        funcionario.Inativar();

        await funcionarioRepositorio.AtualizarAsync(funcionario);
    }

    public async Task AtivarAsync(int id)
    {
        var funcionario = await funcionarioRepositorio.ObterPorIdAsync(id) ?? throw new Exception("Funcionário não encontrado");

        funcionario.Ativar();

        await funcionarioRepositorio.AtualizarAsync(funcionario);
    }

    public async Task AtualizarAsync(AtualizarFuncionarioDto dto)
    {
        var funcionario = await funcionarioRepositorio.ObterPorIdAsync(dto.Id) ?? throw new Exception("Funcionário não encontrado");

        funcionario.Atualizar(dto.Nome, dto.Cpf, dto.Telefone, dto.Endereco);

        await funcionarioRepositorio.AtualizarAsync(funcionario);
    }

    public async Task<IEnumerable<FuncionarioDto>> ListarAsync()
    {
        var result = await funcionarioRepositorio.ListarAsync();

        return result.Select(r => (FuncionarioDto)r);
    }

    public async Task<FuncionarioDto> ObterPorIdAsync(int id)
    {
        var funcionario = await funcionarioRepositorio.ObterPorIdAsync(id) ?? throw new Exception("Funcionário não encontrado");

        return (FuncionarioDto)funcionario;
    }
}