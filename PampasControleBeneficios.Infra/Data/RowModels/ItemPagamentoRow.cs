using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Infra.Data.RowModels;

public class ItemPagamentoRow
{
    public int ID_ITEM_PAGAMENTO { get; private set; }

    public int ID_PAGAMENTO { get; private set; }

    public int ID_TIPO_BENEFICIO { get; private set; }

    public int DIAS_TRABALHADOS { get; private set; }

    public decimal VALOR_DIARIO { get; private set; }

    public decimal SUB_TOTAL { get; private set; }

    public ItemPagamento ToEntity()
    {
        return ItemPagamento.Carregar(ID_ITEM_PAGAMENTO, ID_PAGAMENTO, ID_TIPO_BENEFICIO, DIAS_TRABALHADOS, VALOR_DIARIO, SUB_TOTAL);
    }
}