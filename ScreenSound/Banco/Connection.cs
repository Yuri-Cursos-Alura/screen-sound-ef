using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class Connection
{
    private const string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public static SqlConnection GetConn()
    {
        return new SqlConnection(_connectionString);
    }


}
