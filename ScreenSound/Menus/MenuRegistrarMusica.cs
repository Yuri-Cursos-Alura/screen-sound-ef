using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica(ScreenSoundContext context) : Menu(context)
{
    public override void Executar()
    {
        var dal = new DAL<Artista>(_context);

        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var dbArtista = dal.GetSingle(a => a.Nome.Equals(nomeDoArtista));

        if (dbArtista is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento da música: ");
            string ano = Console.ReadLine()!;
            dbArtista.AdicionarMusica(new Musica(tituloDaMusica) { AnoLancamento = int.Parse(ano) });
            dal.Update(dbArtista);
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
