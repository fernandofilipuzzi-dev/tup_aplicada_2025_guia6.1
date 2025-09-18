using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Diagnostics;

namespace Ejercicio2;

internal class Program
{
    async static Task Main(string[] args)
    {
        string query = @"
SELECT f.Id, f.Tipo, f.Area , f.Ancho, f.Largo, f.Radio
FROM Figuras f
ORDER BY f.Id
";
        string connectionString = "Data Source=172.16.3.38;Initial Catalog=GUI6_1_Ejercicio1_fernando3_db;User ID=admindb;Password=admindb;Pooling=False;Connect Timeout=30;Encrypt=False;Authentication=SqlPassword;Application Name=vscode-mssql;Application Intent=ReadWrite;Command Timeout=30";

        using SqlConnection conn = new SqlConnection(connectionString);

        await conn.OpenAsync();

        SqlCommand cmd = new SqlCommand(query, conn);

        var dataReader =await cmd.ExecuteReaderAsync();

        while (await dataReader.ReadAsync())
        {
            int Id = Convert.ToInt32(dataReader["Id"]);
            //int Tipo = Convert.ToInt32(dataReader["Tipo"]);
            //double? Area = dataReader["Area"]!=DBNull.Value? Convert.ToDouble(dataReader["Area"]):null;
            //double? Ancho = dataReader["Ancho"] != DBNull.Value ? Convert.ToDouble(dataReader["Ancho"]) : null;
            //double? Largo = dataReader["Largo"] != DBNull.Value ? Convert.ToDouble(dataReader["Largo"]) : null;
            //double? Radio = dataReader["Radio"] != DBNull.Value ? Convert.ToDouble(dataReader["Radio"]) : null;

            Console.WriteLine($"{Id,10}|");
        }

    }
}
