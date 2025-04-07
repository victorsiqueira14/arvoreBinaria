
class Program
{
    static ArvoreABB arvore = new ArvoreABB();

    static void Main()
    {
        // Carrega dados salvos do arquivo e insere na árvore
        var livros = Persistencia.Carregar();
        foreach (var livro in livros)
            arvore.Inserir(livro);

        int opcao;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Inserir novo livro");
            Console.WriteLine("2 - Buscar livro por ID");
            Console.WriteLine("3 - Buscar livro por título");
            Console.WriteLine("4 - Listar todos os livros");
            Console.WriteLine("5 - Filtrar por autor");
            Console.WriteLine("6 - Filtrar por ano");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            int.TryParse(Console.ReadLine(), out opcao);

            Console.WriteLine();

            switch (opcao)
            {
                case 1: InserirLivro(); break;
                case 2: BuscarPorId(); break;
                case 3: BuscarPorTitulo(); break;
                case 4: ListarTodos(); break;
                case 5: FiltrarAutor(); break;
                case 6: FiltrarAno(); break;
                case 0: Salvar(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        } while (opcao != 0);
    }

    static void InserirLivro()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        Console.Write("Ano: ");
        int ano = int.Parse(Console.ReadLine());

        if (arvore.BuscarPorId(id) != null)
        {
            Console.WriteLine("ID já existente.");
            return;
        }

        Livro livro = new Livro { 
            Id = id, 
            Titulo = titulo, 
            Autor = autor, 
            Ano = ano 
        };
        
        arvore.Inserir(livro);
        Console.WriteLine("Livro inserido.");
    }

    static void BuscarPorId()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        var livro = arvore.BuscarPorId(id);
        Console.WriteLine(livro != null ? livro.ToString() : "Livro não encontrado.");
    }

    static void BuscarPorTitulo()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        var resultados = arvore.BuscarPorTitulo(titulo);
        MostrarLista(resultados);
    }

    static void ListarTodos()
    {
        var todos = arvore.Listar();
        MostrarLista(todos);
    }

    static void FiltrarAutor()
    {
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        var resultados = arvore.FiltrarPorAutor(autor);
        MostrarLista(resultados);
    }

    static void FiltrarAno()
    {
        Console.Write("Ano: ");
        int ano = int.Parse(Console.ReadLine());
        var resultados = arvore.FiltrarPorAno(ano);
        MostrarLista(resultados);
    }

    static void MostrarLista(List<Livro> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum livro encontrado.");
            return;
        }

        foreach (var livro in lista)
            Console.WriteLine(livro);
    }

    static void Salvar()
    {
        var todos = arvore.Listar();
        Persistencia.Salvar(todos);
        Console.WriteLine("Dados salvos.");
    }
}