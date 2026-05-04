using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioCategoria repositorioCategoria;

    public TelaProduto(RepositorioProduto repositorio, RepositorioCategoria repositorioCategoria)
        : base("Produto", repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produtos");

        List<Produto> produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum registro.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -20} | {3, -15} | {4, -10}",
            "Id", "Nome", "Categoria", "Unidade", "Preço"
        );

        foreach (Produto p in produtos)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -20} | {3, -15} | {4, -10:C}",
                p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.PrecoAproximado
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("---------------------------------");

        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        if (categorias.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma categoria antes de adicionar produtos.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return new Produto(string.Empty, null!, string.Empty, 0);
        }

        Console.WriteLine("Selecione uma categoria:");
        Console.WriteLine("---------------------------------");

        for (int i = 0; i < categorias.Count; i++)
            Console.WriteLine($"{i + 1} - {categorias[i].Nome}");

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o número da categoria: ");
        string opcaoCategoria = Console.ReadLine() ?? string.Empty;

        Categoria? categoriaSelecionada = null;

        if (int.TryParse(opcaoCategoria, out int indiceCategoria) &&
            indiceCategoria >= 1 && indiceCategoria <= categorias.Count)
        {
            categoriaSelecionada = categorias[indiceCategoria - 1];
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Unidades disponíveis: kg, g, litro, ml, unidade, caixa, pacote, dúzia");
        Console.Write("Digite a unidade de medida: ");
        string unidadeMedida = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o preço aproximado (ex: 5,99): ");
        string precoStr = Console.ReadLine() ?? string.Empty;
        decimal.TryParse(precoStr, out decimal preco);

        return new Produto(nome, categoriaSelecionada!, unidadeMedida, preco);
    }

    protected override List<string> ValidarRegistroDuplicado(Produto novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<Produto> produtos = repositorio.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (p.Id != idIgnorado &&
                p.Nome == novaEntidade.Nome &&
                p.Categoria?.Id == novaEntidade.Categoria?.Id)
            {
                erros.Add($"Já existe um produto com o nome \"{novaEntidade.Nome}\" nessa categoria.");
                break;
            }
        }

        return erros;
    }
}