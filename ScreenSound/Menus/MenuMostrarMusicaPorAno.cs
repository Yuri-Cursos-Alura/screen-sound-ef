using ScreenSound.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus;
internal class MenuMostrarMusicaPorAno(ScreenSoundContext context) : Menu(context)
{
    public override void Executar()
    {
        var dal = new DAL<Musica>(_context);

        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o ano da música que deseja visualuzar: ");
        var ano = int.Parse(Console.ReadLine()!);
        var dbMusica = dal.GetMany(a => a.AnoLancamento == ano);
        if (dbMusica.Count() > 0)
        {
            Console.WriteLine($"\nMúsicas lançadas em {ano}:");
            foreach (var musica in dbMusica)
            {
                Console.WriteLine(musica);
                Console.WriteLine("--------------");
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNenhuma música lançada neste ano foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
