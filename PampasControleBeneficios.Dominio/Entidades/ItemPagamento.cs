namespace PampasControleBeneficios.Dominio.Entidades;

public class ItemPagamento
{
    public int Id { get; private set; }

    public int IdPagamento { get; private set; }

    public int IdTipoBeneficio { get; private set; }

    public int DiasTrabalhados { get; private set; }

    public decimal ValorDiario { get; private set; }

    public decimal SubTotal { get; private set; }

    private ItemPagamento(int idTipoBeneficio, int diasTrabalhados, decimal valorDiario)
    {
        IdTipoBeneficio = idTipoBeneficio;
        DiasTrabalhados = diasTrabalhados;
        ValorDiario = valorDiario;
        SubTotal = valorDiario * diasTrabalhados;
    }

    public static ItemPagamento Criar(int idTipoBeneficio, int diasTrabalhados, decimal valorDiario)
    {
        return new ItemPagamento(idTipoBeneficio, diasTrabalhados, valorDiario);
    }

    public static ItemPagamento Carregar(int id, int idPagamento, int idTipoBeneficio, int diasTrabalhados, decimal valorDiario, decimal subTotal)
    {
        return new ItemPagamento(idTipoBeneficio, diasTrabalhados, valorDiario)
        {
            Id = id,
            IdPagamento = idPagamento,
            SubTotal = subTotal
        };
    }
}