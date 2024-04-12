using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class MusicaDAL(ScreenSoundContext? context = null) : DAL<Musica>(context)
{
    public Musica GetSingle(string name) => _context.Musicas.First(a => a.Nome.Equals(name));
}
