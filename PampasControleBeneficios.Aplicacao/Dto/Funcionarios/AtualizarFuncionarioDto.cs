namespace PampasControleBeneficios.Aplicacao.Dto.Funcionarios;

public record AtualizarFuncionarioDto(

    int Id,

    string Nome,

    string Cpf,

    string? Telefone,

    string? Endereco
    
    );
