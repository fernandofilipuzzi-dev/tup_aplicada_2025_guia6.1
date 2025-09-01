
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO


-- listar todo los registro Circulo

SELECT * FROM Figuras;

GO

DECLARE @Tipo INT =1; --rectangulo
DECLARE @Ancho DECIMAL(18,2)=10;
DECLARE @Largo DECIMAL(18,2)=12;
DECLARE @Radio DECIMAL(18,2)=NULL;

IF @Tipo=1
BEGIN

	INSERT INTO Figuras (Tipo, Ancho, Largo)
	OUTPUT INSERTED.Id
	VALUES
	(@Tipo, @Ancho, @Largo)

END

ELSE IF @Tipo=2
BEGIN

	INSERT INTO Figuras (Tipo, Radio)
	OUTPUT INSERTED.Id
	VALUES
	(@Tipo, @Radio)

END

GO

SELECT * FROM Figuras;

GO

USE master