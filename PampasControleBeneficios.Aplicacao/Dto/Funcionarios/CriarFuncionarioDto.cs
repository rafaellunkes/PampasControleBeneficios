namespace PampasControleBeneficios.Aplicacao.Dto.Funcionarios;

public record CriarFuncionarioDto(
    
    string Nome,

    string Cpf,

    string? Telefone,

    string? Endereco

    );
