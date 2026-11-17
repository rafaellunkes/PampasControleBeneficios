using PampasControleBeneficios.Dominio.Entidades;

namespace PampasControleBeneficios.Infra.Data.RowModels;

public record FuncionarioRow
{
    public int ID_FUNCIONARIO { get; private set; }

    public string NOME { get; private set; } = "";

    public string CPF { get; private set; } = "";

    public string? TELEFONE { get; private set; }

    public string? ENDERECO { get; private set; }

    public bool ATIVO { get; private set; }

    public Funcionario ToEntity()
    {
        return Funcionario.Carregar(ID_FUNCIONARIO, NOME, CPF, TELEFONE, ENDERECO, ATIVO);
    }
}