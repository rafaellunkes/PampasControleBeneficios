using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Aplicacao.Dto.Beneficios;

public record BeneficioDto(
    int Id,

    int IdTipoBeneficio,

    string Nome,

    decimal ValorDiario,

    bool Ativo
)
{
    public static implicit operator BeneficioDto(Beneficio b) => new(b.Id, b.IdTipoBeneficio, b.Nome, b.ValorDiario, b.Ativo);
};