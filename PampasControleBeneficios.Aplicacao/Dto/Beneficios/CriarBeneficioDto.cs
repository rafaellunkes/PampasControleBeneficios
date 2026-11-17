namespace PampasControleBeneficios.Aplicacao.Dto.Beneficios;

public record CriarBeneficioDto(
    int IdTipoBeneficio,

    string Nome,

    decimal ValorDiario
);