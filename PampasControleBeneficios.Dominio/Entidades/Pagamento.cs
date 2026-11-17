namespace PampasControleBeneficios.Dominio.Entidades;

public class Pagamento
{
    public int Id { get; private set; }

    public int IdFuncionario { get; private set; }

    public decimal ValorTotal { get; private set; }

    public DateOnly Competencia { get; private set; }

    public bool Pago { get; private set; } = false;

    public DateOnly? DataPagamento { get; private set; }

    private Pagamento(int idFuncionario, DateOnly competencia, decimal valorTotal)
    {
        IdFuncionario = idFuncionario;
        Competencia = competencia;
        ValorTotal = valorTotal;
    }

    public static Pagamento Criar(int idFuncionario, DateOnly competencia, decimal valorTotal)
    {
        return new Pagamento(idFuncionario, competencia, valorTotal);
    }

    public static Pagamento Carregar(int id, int idFuncionario, DateOnly competencia, decimal valorTotal, bool pago, DateOnly? dataPagamento)
    {
        return new Pagamento(idFuncionario, competencia, valorTotal)
        {
            Id = id,
            Pago = pago,
            DataPagamento = dataPagamento
        };
    }

    public void MarcarComoPago()
    {
        if (Pago)
            throw new InvalidOperationException("Pagamento já foi realizado.");
        Pago = true;
        DataPagamento = DateOnly.FromDateTime(DateTime.Now);
    }
}