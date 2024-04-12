using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair(ScreenSoundContext context) : Menu(context)
{
    public override void Executar()
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
