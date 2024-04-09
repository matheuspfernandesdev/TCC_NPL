CREATE TABLE [dbo].[Jurisprudencia](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Processo] [varchar](512) NULL,
	[Relator] [varchar](512) NULL,
	[OrgaoJulgador] [varchar](512) NULL,
	[Sumula] [varchar](512) NULL,
	[DataJulgamento] [varchar](24) NULL,
	[DataPublicacao] [varchar](24) NULL,
	[Ementa] [varchar](max) NULL,
	[InteiroTeor] [varchar](max) NULL
) 

ALTER TABLE Jurisprudencia
	ADD Primary Key (Identificador)


CREATE TABLE [dbo].[Pesquisa](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Pesquisa] [varchar](512) NOT NULL
)

ALTER TABLE Pesquisa
	ADD Primary Key (Identificador)


CREATE TABLE [dbo].[PesquisaJurisprudencia](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[IdentificadorPesquisa] [int] NOT NULL,
	[IdentificadorJurisprudencia] [int] NOT NULL,
)

ALTER TABLE PesquisaJurisprudencia
	ADD Primary Key (Identificador)

ALTER TABLE PesquisaJurisprudencia
	ADD FOREIGN KEY (IdentificadorPesquisa) REFERENCES Pesquisa(Identificador);

ALTER TABLE PesquisaJurisprudencia
	ADD FOREIGN KEY (IdentificadorJurisprudencia) REFERENCES Jurisprudencia(Identificador);