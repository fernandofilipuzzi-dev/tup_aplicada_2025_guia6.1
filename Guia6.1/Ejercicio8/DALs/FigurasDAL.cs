using Ejercicio8.Models;
using Microsoft.Data.SqlClient;

namespace Ejercicio8.DALs;

public class FigurasDAL
{
    string stringConnection = "Data Source=TSP;Initial Catalog=GUIA6_1_Ejercicio1_DB;Integrated Security=True;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";

    async public Task<List<Figura>> GetAll()
    {
        List<Figura> figuras = new List<Figura>();

        #region conexion y comando sql
        string query = @"
SELECT f.Id,
	   f.Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f
ORDER BY f.Area
";
        SqlConnection conn = new SqlConnection(stringConnection);
        await conn.OpenAsync();

        using SqlCommand command = new SqlCommand(query, conn);

        using SqlDataReader dataReader = await command.ExecuteReaderAsync();
        #endregion

        while (await dataReader.ReadAsync())
        {
            #region parseo
            int? id = dataReader["Id"] != DBNull.Value ? Convert.ToInt32(dataReader["Id"]):null;
            int? tipo = dataReader["Tipo"] != DBNull.Value ? Convert.ToInt32(dataReader["Tipo"]):null;
            double? area = Convert.ToInt32(dataReader["Area"] != DBNull.Value ? dataReader["Area"] : null);
            double? ancho = Convert.ToInt32(dataReader["Ancho"] != DBNull.Value ? dataReader["Ancho"] : null);
            double? largo = Convert.ToInt32(dataReader["Largo"] != DBNull.Value ? dataReader["Largo"] : null);
            double? radio = Convert.ToInt32(dataReader["Radio"] != DBNull.Value ? dataReader["Radio"] : null);
            #endregion 

            Figura entidad =null;
            if (tipo == 1)
            {
                //forma abreviada
                entidad = new Rectangulo() { Id=id, Area = area, Ancho = area, Largo =largo};

                //en prog2 sería:
                /*
                Rectangulo rectangulo = new Rectangulo();
                rectangulo.Id = id;
                rectangulo.Area = area;
                rectangulo.Ancho = ancho;
                rectangulo.Largo = largo;
                entidad=rectangulo;
               
                //la mejor forma para prog2
                entidad= new Rectangulo(id,area, ancho, largo); 
                 */
            }
            else if (tipo == 2)
            {
                entidad = new Circulo() { Id = id, Radio = largo };
            }

            figuras.Add(entidad);
        }

        await conn.CloseAsync(); 

        return figuras;
    }

    async public Task<Figura> GetById(int idFigura)
    {
        Figura figura = null;

        string query = @"
SELECT TOP 1 f.Id,
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

        try
        {
            using SqlConnection conn = new SqlConnection(stringConnection);
            await conn.OpenAsync();

            #region comando sql
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", idFigura);
            #endregion

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            if(await dataReader.ReadAsync())
            {
                #region parseo
                int id = dataReader["Id"] != DBNull.Value ? Convert.ToInt32(dataReader["Id"]) : 0;
                int? tipo = dataReader["Tipo"] != DBNull.Value ? Convert.ToInt32(dataReader["Tipo"]) : null;
                double? area = Convert.ToInt32(dataReader["Area"] != DBNull.Value ? dataReader["Area"] : null);
                double? ancho = Convert.ToInt32(dataReader["Ancho"] != DBNull.Value ? dataReader["Ancho"] : null);
                double? largo = Convert.ToInt32(dataReader["Largo"] != DBNull.Value ? dataReader["Largo"] : null);
                double? radio = Convert.ToInt32(dataReader["Radio"] != DBNull.Value ? dataReader["Radio"] : null);
                #endregion

                if (tipo == 1)
                {
                    figura = new Rectangulo() { Id=id, Area=area, Ancho=ancho, Largo=largo};
                }
                else if (tipo == 2)
                {
                    figura = new Circulo() { Id = id, Area = area, Radio = radio };
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return figura;
    }
    
    async public Task<Figura> Save(Figura nuevo)
    {
        int tipo = 0;
        double? ancho = null;
        double? largo = null;
        double? radio = null;

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

            using SqlCommand comm = new SqlCommand(query, conn);

            
            if (nuevo is Rectangulo r)
            { 
                tipo = 1;
                ancho = r.Ancho;
                largo = r.Largo;
            }
            else if (nuevo is Circulo c)
            {
                tipo = 2;
                radio = c.Radio;
            }

            comm.Parameters.AddWithValue("@Tipo", tipo);
            comm.Parameters.AddWithValue("@Ancho", ancho);
            comm.Parameters.AddWithValue("@Largo", largo);
            comm.Parameters.AddWithValue("@Radio", radio=0.0);

            object idObject = await comm.ExecuteScalarAsync();

            nuevo.Id=Convert.ToInt32( idObject );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
        return nuevo;
    }

    async public Task<bool> Remove(int idFigura)
    {
        string query = @"
DELETE 
FROM Figuras 
WHERE Id=@Id_Figura
";

        try
        {
            using SqlConnection conn = new SqlConnection(stringConnection);
            await conn.OpenAsync();

            #region sqlcommand
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id_Figura", idFigura);
            #endregion

            int cantidad = await cmd.ExecuteNonQueryAsync();

            return cantidad>0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return false;
    }

}
