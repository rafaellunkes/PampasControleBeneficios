using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Aplicacao.Dto.ItensPagamento;

public record ItemPagamentoDto(

    int Id,

    int IdPagamento,

    int IdTipoBeneficio,

    int DiasTrabalhados,

    decimal ValorDiario,

    decimal SubTotal
)
{
    public static implicit operator ItemPagamentoDto(ItemPagamento iP) => new(iP.Id, iP.IdPagamento, iP.IdTipoBeneficio, iP.DiasTrabalhados, iP.ValorDiario, iP.SubTotal);
}