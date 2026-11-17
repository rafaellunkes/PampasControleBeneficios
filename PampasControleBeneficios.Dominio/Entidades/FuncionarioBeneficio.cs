namespace PampasControleBeneficios.Dominio.Entidades;

public class FuncionarioBeneficio
{
    public int Id { get; private set; }

    public int IdFuncionario { get; private set; }

    public int IdBeneficio { get; private set; }

    private FuncionarioBeneficio(int idFuncionario, int idBeneficio)
    {
        IdFuncionario = idFuncionario;
        IdBeneficio = idBeneficio;
    }

    public static FuncionarioBeneficio Criar(int idFuncionario, int idBeneficio)
    {
        return new FuncionarioBeneficio(idFuncionario, idBeneficio);
    }

    public static FuncionarioBeneficio Carregar(int id, int idFuncionario, int idBeneficio)
    {
        return new FuncionarioBeneficio(idFuncionario, idBeneficio)
        {
            Id = id
        };
    }
}