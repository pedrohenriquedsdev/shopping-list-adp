using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public string UnidadeMedida { get; private set; }
    public decimal PrecoAproximado { get; private set; }

    public Produto(string nome, Categoria categoria, string unidadeMedida, decimal precoAproximado)
    {
        Nome = nome;
        Categoria = categoria;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" é obrigatório.");

        if (string.IsNullOrWhiteSpace(UnidadeMedida))
            erros.Add("O campo \"Unidade de Medida\" é obrigatório.");

        if (PrecoAproximado <= 0)
            erros.Add("O campo \"Preço Aproximado\" deve ser um valor positivo.");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        PrecoAproximado = produtoAtualizado.PrecoAproximado;
    }
}