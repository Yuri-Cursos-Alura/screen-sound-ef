using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Modelos;

public class Artista
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string FotoPerfil { get; set; }
    [Required]
    public string Bio { get; set; }

    public virtual ICollection<Musica> Musicas { get; set; } = [];

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano de lançamento: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
Nome: {Nome}
Foto de Perfil: {FotoPerfil}
Bio: {Bio}";
    }
}