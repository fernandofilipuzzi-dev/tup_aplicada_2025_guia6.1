using Microsoft.Data.SqlClient;

namespace Ejercicio3;

internal class Program
{
    async static Task Main(string[] args)
    {
        int idFigura = 3;

        string query = @"
SELECT f.Id,
	   CASE WHEN f.Tipo=1 THEN 'Rectangulo'
			WHEN f.Tipo=2 THEN 'Circulo'
	   ELSE 'Desconocido' END AS Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f
WHERE f.Id=@Id
ORDER BY f.Area
";

        string stringConnection = "Data Source=TSP;Initial Catalog=GUIA6_1_Ejercicio1_DB;Integrated Security=True;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";

        try
        {
            using SqlConnection conn = new SqlConnection(stringConnection);
            await conn.OpenAsync();

            #region comando sql
            using SqlCommand cmd = new SqlCommand(query, conn);            
            cmd.Parameters.AddWithValue("@Id", idFigura);
            #endregion

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            Console.WriteLine($"{"Id",10}|{"Tipo",10}|{"Area",10}|{"Ancho",10}|{"Largo",10}|{"Radio",10}");
            while (await dataReader.ReadAsync())
            {
                #region parseo
                int id = dataReader["Id"] != DBNull.Value ? Convert.ToInt32(dataReader["Id"]) : 0;
                //
                //
                //int? tipo = dataReader["Tipo"] != DBNull.Value ? Convert.ToString(dataReader["Tipo"]) : null;

                int? tipo = dataReader.IsDBNull(dataReader.GetOrdinal("Tipo"))? null: dataReader.GetInt32(dataReader.GetOrdinal("Tipo"));

                double? area = Convert.ToInt32(dataReader["Area"] != DBNull.Value ? dataReader["Area"] : null);
                double? ancho = Convert.ToInt32(dataReader["Ancho"] != DBNull.Value ? dataReader["Ancho"] : null);
                double? largo = Convert.ToInt32(dataReader["Largo"] != DBNull.Value ? dataReader["Largo"] : null);
                double? radio = Convert.ToInt32(dataReader["Radio"] != DBNull.Value ? dataReader["Radio"] : null);


                #endregion

                Console.WriteLine($"{id,10}|{tipo,10}|{area,10:f2}|{ancho,10:f2}|{largo,10:f2}|{radio,10:f2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
