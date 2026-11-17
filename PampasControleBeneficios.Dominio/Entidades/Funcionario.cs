namespace PampasControleBeneficios.Dominio.Entidades;

public class Funcionario
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = "";

    public string Cpf { get; private set; } = "";

    public string? Telefone { get; private set; }

    public string? Endereco { get; private set; }

    public bool Ativo { get; private set; } = true;

    private Funcionario(string nome, string cpf, string? telefone, string? endereco)
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
    }

    public static Funcionario Criar(string nome, string cpf, string? telefone, string? endereco)
    {
        return new Funcionario(nome, cpf, telefone, endereco);
    }

    public static Funcionario Carregar(int id, string nome, string cpf, string? telefone, string? endereco, bool ativo)
    {
        return new Funcionario(nome, cpf, telefone, endereco)
        {
            Id = id,
            Ativo = ativo
        };
    }

    public void Atualizar(string nome, string cpf, string? telefone, string? endereco)
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
    }

    public void Inativar()
    {
        Ativo = false;
    }

    public void Ativar()
    {
        Ativo = true;
    }
}