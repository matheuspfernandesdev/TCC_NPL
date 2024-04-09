
CREATE TABLE [dbo].[Tutela](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Caminho] [varchar](512) NULL,
	[Texto] [varchar](max) NOT NULL,
	[Aprovada] [int] NULL
) 

ALTER TABLE Tutela
	ADD Primary Key (Identificador)