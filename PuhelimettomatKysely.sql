-- Haetaan puhelimettomat työntekijät

USE Henkilosto
GO

SELECT Sukunimi, Etunimi
FROM dbo.puhelinluettelo
WHERE Puhelinnumero IS NULL
ORDER BY Sukunimi, Etunimi;

