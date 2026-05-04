using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class ListaCompras : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusLista Status { get; private set; }

    public ListaCompras(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;
        Status = StatusLista.Aberta;
    }

    public void Concluir()
    {
        Status = StatusLista.Concluida;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaCompras listaAtualizada = (ListaCompras)entidadeAtualizada;
        Nome = listaAtualizada.Nome;
    }
}