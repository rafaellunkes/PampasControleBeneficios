namespace PampasControleBeneficios.Aplicacao.Dto.PagamentoDto;

public record CriarPagamentoDto(
    int IdFuncionario,

    DateOnly Competencia,

    int QtdDiasTrabalhados
    );