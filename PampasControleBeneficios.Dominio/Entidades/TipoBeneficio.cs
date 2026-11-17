namespace PampasControleBeneficios.Dominio.Entidades;

public class TipoBeneficio
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = "";

    public bool PermiteMultiplasLinhas { get; private set; } = false;

    public int MultiplicadorDiario { get; private set; } = 1;

    private TipoBeneficio(string nome, bool permiteMultiplasLinhas, int multiplicadorDiario)
    {
        Nome = nome;
        PermiteMultiplasLinhas = permiteMultiplasLinhas;
        MultiplicadorDiario = multiplicadorDiario;
    }

    public static TipoBeneficio Criar(string nome, bool permiteMultiplasLinhas = false, int multiplicadorDiario = 1)
    {
        return new TipoBeneficio(nome, permiteMultiplasLinhas, multiplicadorDiario);
    }

    public static TipoBeneficio Carregar(int id, string nome, bool permiteMultiplasLinhas, int multiplicadorDiario)
    {
        return new TipoBeneficio(nome, permiteMultiplasLinhas, multiplicadorDiario)
        {
            Id = id
        };
    }

    public void Atualizar(string nome, bool permiteMultiplasLinhas, int multiplicadorDiario)
    {
        Nome = nome;
        PermiteMultiplasLinhas = permiteMultiplasLinhas;
        MultiplicadorDiario = multiplicadorDiario;
    }
}