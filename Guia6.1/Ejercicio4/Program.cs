using Microsoft.Data.SqlClient;

namespace Ejercicio4;

internal class Program
{
    async static Task Main(string[] args)
    {
        int? tipo = 1;
        double? ancho = 23;
        double? largo = 12;

        string query = @"
INSERT INTO Figuras (Tipo, Ancho, Largo, Radio)
OUTPUT INSERTED.Id
VALUES
(@Tipo, @Ancho, @Largo, @Radio)
";

        string stringConnection = "Data Source=TSP;Initial Catalog=GUIA6_1_Ejercicio1_DB;Integrated Security=True;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";

        try
        {
            using SqlConnection conn = new SqlConnection(stringConnection);
            await conn.OpenAsync();

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Tipo", tipo);
            cmd.Parameters.AddWithValue("@Ancho", ancho);
            cmd.Parameters.AddWithValue("@Largo", largo);
            cmd.Parameters.AddWithValue("@Radio", largo);

            object idObject = await cmd.ExecuteScalarAsync();

            Console.WriteLine($"Id Figura insertada: {Convert.ToInt32(idObject)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }        
    }
}
