using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class ArtistaDAL
{
    public static IEnumerable<Artista> ListarArtistas()
    {
        var lista = new List<Artista>();

        using var conn = Connection.GetConn();
        conn.Open();

        string sql = "SELECT * FROM Artistas";
        var command = new SqlCommand(sql, conn);

        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string? nomeArtista = Convert.ToString(reader["Nome"]);
            string? bioArtista = Convert.ToString(reader["Bio"]);
            int idArtista = Convert.ToInt32(reader["Id"]);

            var artista = new Artista(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);
        }

        return lista;
    }

    public static void AdicionarArtista(Artista artista)
    {
        using var conn = Connection.GetConn();
        conn.Open();

        string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
        var command = new SqlCommand(sql, conn);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }

    public static void AtualizarArtista(string nome, string bio, int idArtista)
    {
        using var conn = Connection.GetConn();
        conn.Open();

        string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
        var command = new SqlCommand(sql, conn);

        command.Parameters.AddWithValue("@nome", nome);
        command.Parameters.AddWithValue("@bio", bio);
        command.Parameters.AddWithValue("@id", idArtista);

        var retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");

    }

    public static void DeletarArtista(int idArtista)
    {
        using var conn = Connection.GetConn();
        conn.Open();

        string sql = "DELETE FROM Artistas WHERE Id = @id";
        var command = new SqlCommand(sql, conn);

        command.Parameters.AddWithValue("@id", idArtista);

        var retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");

    }
}
