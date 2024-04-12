﻿using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;


using (var dal = new MusicaDAL())
{
    foreach(var musica in dal.ListarMusicas())
    {
        Console.WriteLine(musica);
        Console.WriteLine("------------");
    }

    var newMusica = new Musica("The Taste of Cockroach");
    var newMusic2 = new Musica("Placeholder song");
    dal.AdicionarMusicas(newMusica);
    dal.AdicionarMusicas(newMusic2);
    foreach (var musica in dal.ListarMusicas())
    {
        Console.WriteLine(musica);
        Console.WriteLine("------------");
    }

    newMusic2.Nome = "Magical Doctor";
    dal.AtualizarMusicas(newMusic2);
    foreach (var musica in dal.ListarMusicas())
    {
        Console.WriteLine(musica);
        Console.WriteLine("------------");
    }

    dal.DeletarMusicas(newMusic2);
    dal.DeletarMusicas(newMusica);

    foreach (var musica in dal.ListarMusicas())
    {
        Console.WriteLine(musica);
        Console.WriteLine("------------");
    }
}

return;

Dictionary<int, Menu> opcoes = [];

using (var db = new ScreenSoundContext())
{
    opcoes.Add(1, new MenuRegistrarArtista(db));
    opcoes.Add(2, new MenuRegistrarMusica(db));
    opcoes.Add(3, new MenuMostrarArtistas(db));
    opcoes.Add(4, new MenuMostrarMusicas(db));
    opcoes.Add(-1, new MenuSair(db));

    ExibirOpcoesDoMenu();
}
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.TryGetValue(opcaoEscolhidaNumerica, out Menu? menuASerExibido))
    {
        menuASerExibido.Executar();
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

