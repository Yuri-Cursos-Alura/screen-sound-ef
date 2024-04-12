using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ScreenSound.Modelos;

internal class Musica
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    public int? AnoLancamento { get; set; }

    [Required]
    public Artista? Artista { get; set; }

    public Musica(string nome)
    {
        Nome = nome;
    }
    public Musica(string nome, Artista artista)
    {
        Nome = nome;
        Artista = artista;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
Nome: {Nome}";
    }
}