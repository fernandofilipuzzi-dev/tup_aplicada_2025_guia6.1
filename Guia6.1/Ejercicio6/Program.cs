using Microsoft.Data.SqlClient;

namespace Ejercicio6;

internal class Program
{
    async static Task Main(string[] args)
    {
        #region ejemplos de valores parametros a modificar
        int idFigura = 4;
        #endregion

        string query = @"
DELETE 
FROM Figuras 
WHERE Id=@Id_Figura
";

        string stringConnection = "Data Source=TSP;Initial Catalog=GUIA6_1_Ejercicio1_DB;Integrated Security=True;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";

        try
        {
            using SqlConnection conn = new SqlConnection(stringConnection);
            await conn.OpenAsync();

            #region sqlcommand
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id_Figura", idFigura);
            #endregion
            
            int cantidad = await cmd.ExecuteNonQueryAsync();

            Console.WriteLine($"La cantidad de registros eliminados:{cantidad}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
