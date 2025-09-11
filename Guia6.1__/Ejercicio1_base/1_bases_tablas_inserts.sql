

USE master

GO

DROP TABLE IF EXISTS GUI6_1_Ejercicio1_fernando3_db

GO

CREATE DATABASE GUI6_1_Ejercicio1_fernando3_db

GO

USE GUI6_1_Ejercicio1_fernando3_db

GO

CREATE TABLE Figuras(
  Id INT IDENTITY(1,1),
  Tipo INT,
  Area DECIMAL(18,2),
  Ancho DECIMAL(18,2),
  Largo DECIMAL(18,2),
  Radio DECIMAL(18,2),
  CONSTRAINT PK_Figuras PRIMARY KEY (Id),
  CONSTRAINT CK_Tipo CHECK (Tipo IN (1,2))
)



--DECLARE @Figuras TABLE(
--  Id INT IDENTITY(1,1),
--  Tipo INT,
--  Area DECIMAL(18,2),
--  Ancho DECIMAL(18,2),
--  Largo DECIMAL(18,2),
--  Radio DECIMAL(18,2),
--  CONSTRAINT PK_Figuras PRIMARY KEY (Id),
--  CONSTRAINT CK_Tipo CHECK (Tipo IN (1,2))
--)


GO

INSERT INTO Figuras (Tipo, Ancho, Largo, Radio)
VALUES
( 1,  1, 1, NULL),
( 1,  1, 2, NULL),
( 1,  2.1, 1, NULL),
( 2,  NULL, NULL, 1),
( 2,  NULL, NULL, 2.1)

GO


SELECT f.Id, f.Tipo, f.Area , f.Ancho, f.Largo, f.Radio
FROM Figuras f


USE master
