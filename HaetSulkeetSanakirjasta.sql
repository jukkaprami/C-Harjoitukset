/*
-- Kysely, jolla haetaan sulkeiden nimet Suomi_Englanti-näkymästä
*/

USE ITsanasto
GO

SELECT *
FROM dbo.Suomi_Englanti
WHERE Suomi like '%sulku'
ORDER BY Suomi