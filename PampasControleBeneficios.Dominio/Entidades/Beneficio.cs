namespace PampasControleBeneficios.Dominio.Entidades;

public class Beneficio
{
    public int Id { get; private set; }

    public int IdTipoBeneficio { get; private set; }

    public string Nome { get; private set; } = "";

    public decimal ValorDiario { get; private set; }

    public bool Ativo { get; private set; }

    private Beneficio(int idTipoBeneficio, string nome, decimal valorDiario, bool ativo)
    {
        IdTipoBeneficio = idTipoBeneficio;
        Nome = nome;
        ValorDiario = valorDiario;
        Ativo = ativo;
    }

    public static Beneficio Criar(int idTipoBeneficio, string nome, decimal valorDiario, bool ativo)
    {
        return new Beneficio(idTipoBeneficio, nome, valorDiario, ativo);
    }

    public static Beneficio Carregar(int id, int idTipoBeneficio, string nome, decimal valorDiario, bool ativo)
    {
        return new Beneficio(idTipoBeneficio, nome, valorDiario, ativo)
        {
            Id = id
        };
    }

    public void Atualizar(int idTipoBeneficio, string nome, decimal valorDiario, bool ativo)
    {
        IdTipoBeneficio = idTipoBeneficio;
        Nome = nome;
        ValorDiario = valorDiario;
        Ativo = ativo;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void Ativar()
    {
        Ativo = true;
    }
}