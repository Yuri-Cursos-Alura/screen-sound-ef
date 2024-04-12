using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class ArtistaDAL(ScreenSoundContext? context = null) : IDisposable
{
    private readonly ScreenSoundContext _context = context ?? new ScreenSoundContext();

    public void Dispose()
    {
        _context.Dispose();
    }

    public List<Artista> ListarArtistas() => [.. _context.Artistas];

    public void AdicionarArtista(Artista artista)
    {
        _context.Artistas.Add(artista);
        _context.SaveChanges();
    }

    public void DeletarArtista(Artista artista)
    {
        _context.Artistas.Remove(artista);
        _context.SaveChanges();
    }

    public void AtualizarArtista(Artista artistaAdd)
    {
        _context.Artistas.Update(artistaAdd);
        _context.SaveChanges();
    }

    public Artista? GetArtista(string nome) => _context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
}
