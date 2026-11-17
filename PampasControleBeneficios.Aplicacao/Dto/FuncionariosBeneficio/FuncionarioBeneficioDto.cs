using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Aplicacao.Dto.FuncionariosBeneficio;

public record FuncionarioBeneficioDto(
    int Id,
    int IdFuncionario,
    int IdBeneficio
)
{
    public static implicit operator FuncionarioBeneficioDto(FuncionarioBeneficio fB) => new(fB.Id, fB.IdFuncionario, fB.IdBeneficio);
}