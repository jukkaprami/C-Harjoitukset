/*
-- Kysely, jolla haetaan sulkeiden nimet Suomi_Englanti-n�kym�st�
*/

USE ITsanasto
GO

SELECT *
FROM dbo.Suomi_Englanti
WHERE Suomi like '%sulku'
ORDER BY Suomi