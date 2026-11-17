using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Infra.Data.RowModels;

public class BeneficioRow
{
    public int ID_BENEFICIO { get; set; }

    public int ID_TIPO_BENEFICIO { get; set; }

    public string NOME { get; set; } = "";

    public decimal VALOR_DIARIO { get; set; }

    public bool ATIVO { get; set; }

    public Beneficio ToEntity()
    {
        return Beneficio.Carregar(ID_BENEFICIO, ID_TIPO_BENEFICIO, NOME, VALOR_DIARIO, ATIVO);
    }
}