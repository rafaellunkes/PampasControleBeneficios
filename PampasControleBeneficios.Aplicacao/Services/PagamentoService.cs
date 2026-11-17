using PampasControleBeneficios.Aplicacao.Dto.Funcionarios;
using PampasControleBeneficios.Aplicacao.Dto.PagamentoDto;
using PampasControleBeneficios.Dominio.Entidades;
using PampasControleBeneficios.Dominio.Interfaces;

namespace PampasControleBeneficios.Aplicacao.Services;

public class PagamentoService(
    FuncionarioBeneficioService funcionarioBeneficioService,
    FuncionarioService funcionarioService,


    IPagamentoRepositorio pagamentoRepositorio,
    IItemPagamentoRepositorio itemPagamentoRepositorio)
{
    public async Task CriarPagamentoAsync(CriarPagamentoDto dto)
    {
        // buscar funcionario para validar
        var funcionario = await funcionarioService.ObterPorIdAsync(dto.IdFuncionario);

        // buscar funcionarioBeneficios pra pegar os ids dos beneficios
        var beneficios = await funcionarioBeneficioService.ListarBeneficiosPorFuncionarioAsync(funcionario.Id);

        // criar itens pagamento
        var itens = beneficios.ToList().Select(b =>
        {
            return ItemPagamento.Criar(b.Id, dto.QtdDiasTrabalhados, b.ValorDiario);
        });

        // calcular o valor total e atribuir ao pagamento
        decimal valorTotal = itens.Sum(i => i.SubTotal);

        var pagamento = Pagamento.Criar(funcionario.Id, dto.Competencia, valorTotal);

        // persistencia
        // gravar o pagamento primeiro, retornando o id pra ser usado na persistencia dos itensPagamento
        var idNovoPagamento = await pagamentoRepositorio.Cadastrar(pagamento);

        // gravar os itensPagamento no banco usando o idPagamento retornado do insert anterior
        await itemPagamentoRepositorio.Cadastrar(idNovoPagamento, itens);
    }
}