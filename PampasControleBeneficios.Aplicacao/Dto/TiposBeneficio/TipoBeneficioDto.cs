using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Aplicacao.Dto.TiposBeneficio;

public record TipoBeneficioDto(
    int Id,

    string Nome
)
{
    public static implicit operator TipoBeneficioDto(TipoBeneficio t) => new(t.Id, t.Nome);
}