public class No
{
    public Livro Livro { get; set; }
    public No Esquerda { get; set; }
    public No Direita { get; set; }

    public No(Livro livro)
    {
        Livro = livro;
    }
}