public class ArvoreABB
{
    public No Raiz { get; set; }

    public void Inserir(Livro livro)
    {
        Raiz = InserirRec(Raiz, livro);
    }

    private No InserirRec(No atual, Livro livro)
    {
        if (atual == null) return new No(livro);

        if (livro.Id < atual.Livro.Id)
            atual.Esquerda = InserirRec(atual.Esquerda, livro);

        if (livro.Id > atual.Livro.Id)
            atual.Direita = InserirRec(atual.Direita, livro);
                
        return atual;
    }

    public Livro BuscarPorId(int id)
    {
        var atual = Raiz;
        
        while (atual != null)
        {
            if (id == atual.Livro.Id) return atual.Livro;

            atual = id < atual.Livro.Id ? atual.Esquerda : atual.Direita;
        }
        
        return null;
    }

    public List<Livro> Listar()
    {
        var lista = new List<Livro>();
        InOrder(Raiz, lista);
        return lista;
    }

    private void InOrder(No atual, List<Livro> lista)
    {
        if (atual != null)
        {
            InOrder(atual.Esquerda, lista);
            lista.Add(atual.Livro);
            InOrder(atual.Direita, lista);
        }
    }

    public List<Livro> BuscarPorTitulo(string titulo)
    {
        var lista = new List<Livro>();
        BuscarTituloRec(Raiz, titulo.ToLower(), lista);
        return lista;
    }

    private void BuscarTituloRec(No atual, string titulo, List<Livro> lista)
    {
        if (atual != null)
        {
            if (atual.Livro.Titulo.ToLower().Contains(titulo))
                lista.Add(atual.Livro);
            
            BuscarTituloRec(atual.Esquerda, titulo, lista);
            BuscarTituloRec(atual.Direita, titulo, lista);
        }
    }

    public List<Livro> FiltrarPorAno(int ano) =>
        Listar().Where(l => l.Ano == ano).ToList();

    public List<Livro> FiltrarPorAutor(string autor) =>
        Listar().Where(l => l.Autor.ToLower().Contains(autor.ToLower())).ToList();
}