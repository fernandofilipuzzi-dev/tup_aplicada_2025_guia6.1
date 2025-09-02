using Microsoft.Data.SqlClient;

namespace Ejercicio5;

internal class Program
{
    async static Task Main(string[] args)
    {
        #region ejemplos de valores parametros a modificar
        int idFigura = 3;

        int tipo = 2;
        double? area = 0;
        double? ancho = 0;
        double? largo = 0;
        double? radio = 1;
        #endregion

        # region simulo la actualización - ejemplo calculando el area.
        if (tipo == 1)
            area = ancho * largo;
        else if (tipo == 2)
            area = Math.PI * Math.Pow(radio??0, 2);
        #endregion

        string query = @"
UPDATE Figuras SET Area=@Area, Ancho=@Ancho, Largo=@Largo, Radio=@Radio
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
            cmd.Parameters.AddWithValue("@Tipo", tipo);
            cmd.Parameters.AddWithValue("@Area", area);
            cmd.Parameters.AddWithValue("@Ancho", ancho);
            cmd.Parameters.AddWithValue("@Largo", largo);
            cmd.Parameters.AddWithValue("@Radio", radio);
            #endregion

            object? objectCantidad = await cmd.ExecuteScalarAsync();

            int cantidad = Convert.ToInt32(objectCantidad);

            Console.WriteLine($"La cantidad de registros modificadas fue:{cantidad}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());   
        }
    }
}
