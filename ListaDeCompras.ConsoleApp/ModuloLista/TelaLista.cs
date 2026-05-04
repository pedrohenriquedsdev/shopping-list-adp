using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloItem;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class TelaLista : TelaBase<ListaCompras>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioItem repositorioItem;

    public TelaLista(RepositorioLista repositorio, RepositorioItem repositorioItem)
        : base("Lista de Compras", repositorio)
    {
        this.repositorioItem = repositorioItem;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Listas de Compras");

        List<ListaCompras> listas = repositorio.SelecionarTodos();

        if (listas.Count == 0)
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
            "{0, -7} | {1, -30} | {2, -12} | {3, -10} | {4, -8} | {5, -12}",
            "Id", "Nome", "Data", "Status", "Itens", "Total Est."
        );

        foreach (ListaCompras l in listas)
        {
            List<ItemLista> itens = repositorioItem.SelecionarPorLista(l.Id);
            decimal totalEstimado = itens.Sum(i => i.Produto.PrecoAproximado * i.Quantidade);

            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -12} | {3, -10} | {4, -8} | {5, -12:C}",
                l.Id, l.Nome, l.DataCriacao.ToShortDateString(), l.Status, itens.Count, totalEstimado
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override ListaCompras ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da lista de compras: ");
        string nome = Console.ReadLine() ?? string.Empty;

        return new ListaCompras(nome);
    }

    protected override List<string> ValidarExclusaoRegistro(ListaCompras registro)
    {
        List<string> erros = new List<string>();

        List<ItemLista> itens = repositorioItem.SelecionarPorLista(registro.Id);

        if (itens.Count > 0)
            erros.Add($"Não é possível excluir a lista \"{registro.Nome}\" pois ela possui {itens.Count} item(ns) vinculado(s).");

        return erros;
    }
}