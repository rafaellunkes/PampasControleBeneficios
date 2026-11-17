using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Infra.Data.RowModels;

public class FuncionarioBeneficioRow
{
    public int ID_FUNCIONARIO_BENEFICIO { get; set; }

    public int ID_FUNCIONARIO { get; set; }

    public int ID_BENEFICIO { get; set; }

    public FuncionarioBeneficio ToEntity()
    {
        return FuncionarioBeneficio.Carregar(ID_FUNCIONARIO_BENEFICIO, ID_FUNCIONARIO, ID_BENEFICIO);
    }
}