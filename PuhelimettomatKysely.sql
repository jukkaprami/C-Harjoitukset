-- Haetaan puhelimettomat ty�ntekij�t

USE Henkilosto
GO

SELECT Sukunimi, Etunimi
FROM dbo.puhelinluettelo
WHERE Puhelinnumero IS NULL
ORDER BY Sukunimi, Etunimi;

