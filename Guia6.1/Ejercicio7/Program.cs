using Microsoft.Data.SqlClient;

namespace Ejercicio7;

internal class Program
{
    async static Task Main(string[] args)
    {
        string query = "sp_CalcularAreas";//no se puede usar @ porque no toma los saltos de linea

        string stringConnection = "Data Source=TSP;Initial Catalog=GUIA6_1_Ejercicio1_DB;Integrated Security=True;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";

        try
        {
            using SqlConnection conn = new SqlConnection(stringConnection);
            await conn.OpenAsync();

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            await cmd.ExecuteNonQueryAsync();
          
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
