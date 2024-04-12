using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class MusicaDAL(ScreenSoundContext? context = null) : IDisposable
{
    private readonly ScreenSoundContext _context = context ?? new ScreenSoundContext();

    public void Dispose()
    {
        _context.Dispose();
    }

    public List<Musica> ListarMusicas() => [.. _context.Musicas];

    public void AdicionarMusicas(Musica musicaAdd)
    {
        _context.Musicas.Add(musicaAdd);
        _context.SaveChanges();
    }

    public void DeletarMusicas(Musica musicaDelete)
    {
        _context.Musicas.Remove(musicaDelete);
        _context.SaveChanges();
    }

    public void AtualizarMusicas(Musica musicaUpdate)
    {
        _context.Musicas.Update(musicaUpdate);
        _context.SaveChanges();
    }

    public Musica? GetMusica(string nome) => _context.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));
}
