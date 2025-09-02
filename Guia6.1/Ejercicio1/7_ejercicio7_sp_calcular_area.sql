
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO


-- d- Crear un  procedimiento para calcular el área de una figura por Id

CREATE OR ALTER PROCEDURE sp_CalcularArea
(
  @Id INT
)
AS
BEGIN
	UPDATE Figuras 
	SET
		Area = CASE 
					WHEN Tipo=1 THEN Ancho*Largo	
					WHEN Tipo=2 THEN 3.14*power( Radio, 2) 
					ELSE NULL
			   END
	WHERE Id=@Id;
END

GO

-- e- Calcular el area de un rectangulo y un circulo previamente insertados

EXEC sp_CalcularArea 1

EXEC sp_CalcularArea 3

SELECT f.Id,
	   CASE WHEN f.Tipo=1 THEN 'Rectangulo'
			WHEN f.Tipo=2 THEN 'Circulo'
	   ELSE 'Desconocido' END AS Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f
WHERE f.Id IN (1, 3);

GO

-- f- Calcular el area de todas las figuras (Cursor)


DECLARE Figura_CURSOR CURSOR FOR SELECT f.Id FROM Figuras f;

OPEN Figura_CURSOR;

DECLARE @Id INT;
FETCH NEXT FROM Figura_CURSOR INTO @Id;

WHILE @@FETCH_STATUS = 0 
BEGIN
	
	EXEC sp_CalcularArea @Id;

	PRINT @Id

    --entrar en bucle
	FETCH NEXT FROM Figura_CURSOR INTO @Id;
END

CLOSE Figura_CURSOR;

DEALLOCATE Figura_CURSOR;

GO

-- g- Consultar todas las figuras con sus áreas calculadas

SELECT f.Id,
	   CASE WHEN f.Tipo=1 THEN 'Rectangulo'
			WHEN f.Tipo=2 THEN 'Circulo'
	   ELSE 'Desconocido' END AS Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f;

USE master

