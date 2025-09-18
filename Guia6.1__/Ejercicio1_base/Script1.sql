
USE GUI6_1_Ejercicio1_fernando3_db

DECLARE @Idf INT 

SET @Idf=3;

SELECT TOP 1 f.Id, f.Tipo, f.Area , f.Ancho, f.Largo, f.Radio
FROM Figuras f
WHERE Id=@Idf
ORDER BY f.Id

USE master
