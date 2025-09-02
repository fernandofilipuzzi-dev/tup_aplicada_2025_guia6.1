
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO


DECLARE @Id_Figura INT=3;

SELECT * FROM Figuras WHERE Id=@Id_Figura;

--

DELETE FROM Figuras 
WHERE Id=@Id_Figura

--

SELECT * FROM Figuras WHERE Id=@Id_Figura;

GO

USE master