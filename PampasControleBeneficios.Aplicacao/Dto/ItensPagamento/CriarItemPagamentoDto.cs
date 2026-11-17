namespace PampasControleBeneficios.Aplicacao.Dto.ItensPagamento;

public record CriarItemPagamentoDto(

    int IdBeneficio,

    int DiasTrabalhados,

    decimal ValorDiario
    
);