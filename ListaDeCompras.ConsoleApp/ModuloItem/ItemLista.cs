using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloItem;

public class ItemLista : EntidadeBase
{
    public string ListaId { get; private set; }
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }

    public ItemLista(string listaId, Produto produto, int quantidade)
    {
        ListaId = listaId;
        Produto = produto;
        Quantidade = quantidade;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Produto == null)
            erros.Add("O campo \"Produto\" é obrigatório.");

        if (Quantidade <= 0)
            erros.Add("O campo \"Quantidade\" deve ser um número positivo.");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ItemLista itemAtualizado = (ItemLista)entidadeAtualizada;

        Quantidade = itemAtualizado.Quantidade;
    }
}