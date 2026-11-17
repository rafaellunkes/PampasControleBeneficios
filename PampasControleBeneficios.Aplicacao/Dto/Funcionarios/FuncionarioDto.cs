using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Aplicacao.Dto.Funcionarios;

public record FuncionarioDto(
    int Id,

    string Nome,

    string Cpf,

    string? Telefone,

    string? Endereco,

    bool Ativo
    )
{
    public static implicit operator FuncionarioDto(Funcionario f) => new(f.Id, f.Nome, f.Cpf, f.Telefone, f.Endereco, f.Ativo);
}