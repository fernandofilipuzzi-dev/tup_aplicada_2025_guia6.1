
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO


DECLARE @Id_Figura INT=3;

SELECT * FROM Figuras WHERE Id=@Id_Figura;

-- Calcular el area y actualizar el valor

DECLARE @Tipo INT;
DECLARE @Area DECIMAL(18,2);
DECLARE @Ancho DECIMAL(18,2);
DECLARE @Largo DECIMAL(18,2);
DECLARE @Radio DECIMAL(18,2);

SELECT @Tipo=f.Tipo, @Ancho=f.Ancho, @Largo=f.Largo, @Radio=f.Radio
FROM Figuras f
WHERE f.Id=@Id_Figura

IF @Tipo=1
BEGIN 
	SET @Area=@Ancho*@Largo
END
ELSE IF @Tipo=2
BEGIN
  SET @Area=3.1415*POWER(@Radio,2);
END 

--

UPDATE Figuras SET Area=@Area, Ancho=@Ancho, Largo=@Largo, Radio=@Radio
WHERE Id=@Id_Figura

--
SELECT * FROM Figuras WHERE Id=@Id_Figura;

GO

USE master