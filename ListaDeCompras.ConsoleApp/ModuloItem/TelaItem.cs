using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloLista;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloItem;

public class TelaItem : TelaBase<ItemLista>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioLista repositorioLista;
    private readonly RepositorioProduto repositorioProduto;
    private string? listaSelecionadaId;

    public TelaItem(
        RepositorioItem repositorio,
        RepositorioLista repositorioLista,
        RepositorioProduto repositorioProduto)
        : base("Item de Lista", repositorio)
    {
        this.repositorioLista = repositorioLista;
        this.repositorioProduto = repositorioProduto;
    }

    public new string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Itens de Lista");
        Console.WriteLine("---------------------------------");

        List<ListaCompras> listas = repositorioLista.SelecionarTodos();

        if (listas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nenhuma lista de compras cadastrada.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return "S";
        }

        Console.WriteLine("Selecione uma lista:");
        Console.WriteLine("---------------------------------");

        for (int i = 0; i < listas.Count; i++)
            Console.WriteLine($"{i + 1} - {listas[i].Nome} [{listas[i].Status}]");

        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcao = Console.ReadLine()?.ToUpper();

        if (opcao == "S") return "S";

        if (int.TryParse(opcao, out int indice) && indice >= 1 && indice <= listas.Count)
        {
            listaSelecionadaId = listas[indice - 1].Id;
        }
        else
        {
            return "S";
        }

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Itens de Lista");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Adicionar item");
        Console.WriteLine("2 - Editar item");
        Console.WriteLine("3 - Remover item");
        Console.WriteLine("4 - Visualizar itens da lista");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        return Console.ReadLine()?.ToUpper();
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Itens da Lista");

        if (listaSelecionadaId == null)
        {
            Console.WriteLine("Nenhuma lista selecionada.");
            return;
        }

        List<ItemLista> itens = ((RepositorioItem)repositorio).SelecionarPorLista(listaSelecionadaId);

        if (itens.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum item nesta lista.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -20} | {3, -8} | {4, -12}",
            "Id", "Produto", "Categoria", "Qtd", "Subtotal"
        );

        decimal totalGeral = 0;

        foreach (ItemLista item in itens)
        {
            decimal subtotal = item.Produto.PrecoAproximado * item.Quantidade;
            totalGeral += subtotal;

            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -20} | {3, -8} | {4, -12:C}",
                item.Id, item.Produto.Nome, item.Produto.Categoria.Nome, item.Quantidade, subtotal
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Total estimado da lista: {totalGeral:C}");

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override ItemLista ObterDadosCadastrais()
    {
        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nenhum produto cadastrado.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return new ItemLista(listaSelecionadaId ?? string.Empty, null!, 0);
        }

        Console.WriteLine("Selecione um produto:");
        Console.WriteLine("---------------------------------");

        for (int i = 0; i < produtos.Count; i++)
            Console.WriteLine($"{i + 1} - {produtos[i].Nome} ({produtos[i].Categoria.Nome}) - {produtos[i].PrecoAproximado:C}/{produtos[i].UnidadeMedida}");

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o número do produto: ");
        string opcaoProduto = Console.ReadLine() ?? string.Empty;

        Produto? produtoSelecionado = null;

        if (int.TryParse(opcaoProduto, out int indiceProduto) &&
            indiceProduto >= 1 && indiceProduto <= produtos.Count)
        {
            produtoSelecionado = produtos[indiceProduto - 1];
        }

        Console.Write("Digite a quantidade: ");
        string qtdStr = Console.ReadLine() ?? string.Empty;
        int.TryParse(qtdStr, out int quantidade);

        return new ItemLista(listaSelecionadaId ?? string.Empty, produtoSelecionado!, quantidade);
    }

    protected override List<string> ValidarRegistroDuplicado(ItemLista novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<ItemLista> itens = ((RepositorioItem)repositorio).SelecionarPorLista(listaSelecionadaId ?? string.Empty);

        foreach (ItemLista item in itens)
        {
            if (item.Id != idIgnorado && item.Produto?.Id == novaEntidade.Produto?.Id)
            {
                erros.Add($"O produto \"{novaEntidade.Produto?.Nome}\" já está nesta lista.");
                break;
            }
        }

        return erros;
    }
}