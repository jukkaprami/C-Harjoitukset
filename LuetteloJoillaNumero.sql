-- Puhelinluettelo niist�, joilla on puhelin

USE Henkilosto
GO

SELECT *
FROM dbo.puhelinluettelo
WHERE Puhelinnumero IS NOT NULL
ORDER BY Sukunimi, Etunimi;
