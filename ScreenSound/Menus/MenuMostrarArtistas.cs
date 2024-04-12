using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas(ScreenSoundContext context) : Menu(context)
{

    public override void Executar()
    {
        var dal = new ArtistaDAL(_context);

        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in dal.ListarArtistas())
        {
            Console.WriteLine($"Artista: {artista.Nome}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
