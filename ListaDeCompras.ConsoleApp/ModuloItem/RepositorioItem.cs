using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloItem;

public class RepositorioItem : RepositorioBase<ItemLista>
{
    public List<ItemLista> SelecionarPorLista(string listaId)
    {
        return registros.Where(i => i.ListaId == listaId).ToList();
    }
}