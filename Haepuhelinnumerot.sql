-- Haetaan ty�ntekij�iden puhelinnumerot
-- WHERE -ehtoa k�ytt�en

USE Henkilosto
GO

SELECT Sukunimi, Etunimi, Puhelinnumero, Liittymatyypiteksti
FROM dbo.Tyontekija, dbo.Liittyma, dbo.Liittymatyyppi
WHERE dbo.Tyontekija.TyontekijaID = dbo.Liittyma.TyontekijaID AND 
dbo.Liittymatyyppi.LiittymatyyppiID = dbo.Liittyma.Tyyppi