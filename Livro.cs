[Serializable]
public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Título: {Titulo}, Autor: {Autor}, Ano: {Ano}";
    }
}