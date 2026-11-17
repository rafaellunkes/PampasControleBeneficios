using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Infra.Data.RowModels;

public class PagamentoRow
{
    public int ID_PAGAMENTO { get; private set; }

    public int ID_FUNCIONARIO { get; private set; }

    public decimal VALOR_TOTAL { get; private set; }

    public DateOnly COMPETENCIA { get; private set; }

    public bool PAGO { get; private set; } = false;

    public DateOnly? DATA_PAGAMENTO { get; private set; }

    public Pagamento ToEntity()
    {
        return Pagamento.Carregar(ID_PAGAMENTO, ID_FUNCIONARIO, COMPETENCIA, VALOR_TOTAL, PAGO, DATA_PAGAMENTO);
    }
}