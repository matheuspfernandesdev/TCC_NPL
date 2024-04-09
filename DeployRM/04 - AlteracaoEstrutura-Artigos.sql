
CREATE TABLE [dbo].[Artigo](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[NomeArtigo] [varchar](32) NOT NULL,
) 

ALTER TABLE Artigo
	ADD Primary Key (Identificador)


--CREATE TABLE [dbo].[PesquisaArtigo](
--	[Identificador] [int] IDENTITY(1,1) NOT NULL,
--	[IdentificadorPesquisa] [int] NOT NULL,
--	[IdentificadorArtigo] [int] NOT NULL,
--) 

--ALTER TABLE PesquisaArtigo
--	ADD Primary Key (Identificador)

--ALTER TABLE PesquisaArtigo
--	ADD FOREIGN KEY (IdentificadorPesquisa) REFERENCES Pesquisa(Identificador);

--ALTER TABLE PesquisaArtigo
	--ADD FOREIGN KEY (IdentificadorArtigo) REFERENCES Artigo(Identificador);


CREATE TABLE [dbo].[JurisprudenciaArtigo](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[IdentificadorJurisprudencia] [int] NOT NULL,
	[IdentificadorArtigo] [int] NOT NULL,
) 

ALTER TABLE JurisprudenciaArtigo
	ADD Primary Key (Identificador)

ALTER TABLE JurisprudenciaArtigo
	ADD FOREIGN KEY (IdentificadorJurisprudencia) REFERENCES Jurisprudencia(Identificador);

ALTER TABLE JurisprudenciaArtigo
	ADD FOREIGN KEY (IdentificadorArtigo) REFERENCES Artigo(Identificador);


