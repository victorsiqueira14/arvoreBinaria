public static class Persistencia
{
    private static string caminho = "livros.dat";

    public static void Salvar(List<Livro> livros)
    {
        using var fs = new FileStream(caminho, FileMode.Create);
        using var writer = new BinaryWriter(fs);

        writer.Write(livros.Count); // Primeiro, escreve o número de livros

        foreach (var livro in livros)
        {
            writer.Write(livro.Id);
            writer.Write(livro.Titulo ?? "");
            writer.Write(livro.Autor ?? "");
            writer.Write(livro.Ano);
        }
    }

    public static List<Livro> Carregar()
    {
        var livros = new List<Livro>();

        if (!File.Exists(caminho)) return livros;

        using var fs = new FileStream(caminho, FileMode.Open);
        using var reader = new BinaryReader(fs);

        int quantidade = reader.ReadInt32();

        for (int i = 0; i < quantidade; i++)
        {
            int id = reader.ReadInt32();
            string titulo = reader.ReadString();
            string autor = reader.ReadString();
            int ano = reader.ReadInt32();

            livros.Add(new Livro {
                Id = id,
                Titulo = titulo,
                Autor = autor,
                Ano = ano
            });
        }

        return livros;
    }
}