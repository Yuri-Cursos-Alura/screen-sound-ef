using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class ArtistaDAL(ScreenSoundContext? context = null) : DAL<Artista>(context)
{
    public Artista GetSingle(string name) => _context.Artistas.First(a => a.Nome.Equals(name));
}
