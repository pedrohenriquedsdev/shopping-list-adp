using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloItem;
using ListaDeCompras.ConsoleApp.ModuloLista;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.Utilidades;

public class TelaPrincipal
{
    private readonly RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
    private readonly RepositorioProduto repositorioProduto = new RepositorioProduto();
    private readonly RepositorioLista repositorioLista = new RepositorioLista();
    private readonly RepositorioItem repositorioItem = new RepositorioItem();

    public TelaPrincipal()
    {
        Categoria categoria = new Categoria("Compras do Mês", CorCategoria.Vermelha);
        repositorioCategoria.Cadastrar(categoria);
    }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("4 - Gerenciar itens de listas de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);

        if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);

        if (opcaoMenuPrincipal == "3")
            return new TelaLista(repositorioLista, repositorioItem);

        if (opcaoMenuPrincipal == "4")
            return new TelaItem(repositorioItem, repositorioLista, repositorioProduto);

        return null;
    }
}