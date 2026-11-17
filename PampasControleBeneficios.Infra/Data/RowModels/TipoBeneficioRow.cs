using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Infra.Data.RowModels;

public class TipoBeneficioRow
{
    public int ID_TIPO_BENEFICIO { get; set; }

    public string NOME { get; set; } = "";

    public bool PERMITE_MULTIPLAS_LINHAS { get; set; }

    public int MULTIPLICADOR_DIARIO { get; set; }

    public TipoBeneficio ToEntity()
    {
        return TipoBeneficio.Carregar(ID_TIPO_BENEFICIO, NOME, PERMITE_MULTIPLAS_LINHAS, MULTIPLICADOR_DIARIO);
    }
}