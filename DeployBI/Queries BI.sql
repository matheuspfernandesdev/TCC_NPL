		 
		 
		 --Quantas jurisprudencias por pesquisa
		Select Count(*) from Jurisprudencia J
				INNER JOIN PesquisaJurisprudencia PJ
			ON J.Identificador = PJ.IdentificadorJurisprudencia
				INNER JOIN Pesquisa P
			ON P.Identificador = PJ.IdentificadorPesquisa AND P.Pesquisa = 'Tutela Medicamentos provisórios idosos'

		--Quantos artigos por pesquisa
		Select count(A.NomeArtigo) as QuantArtigosPorPesquisa from Artigo A
		 where A.Identificador in (

			Select JA.IdentificadorArtigo from JurisprudenciaArtigo JA 
				where JA.IdentificadorJurisprudencia in (

					Select PJ.IdentificadorJurisprudencia from PesquisaJurisprudencia PJ
						where PJ.IdentificadorPesquisa in (
						
							Select P.Identificador from Pesquisa P
								where P.Pesquisa = 'Tutela Medicamentos provisórios idosos'
						
						)

				)
		 )

		--Quantos artigos por jurisprudencia
		Select count(A.NomeArtigo) as QuantArtigosPorJuris from Artigo A
		 where A.Identificador in (
		 
			Select JA.IdentificadorArtigo from JurisprudenciaArtigo JA 
				where JA.IdentificadorJurisprudencia in (

					Select J.Identificador from Jurisprudencia J
						where J.Identificador = 52

				)
		 )

		--Artigos citados na Pesquisa (Select por NomePesquisa)
		Select A.NomeArtigo from Artigo A
		 where A.Identificador in (

			Select JA.IdentificadorArtigo from JurisprudenciaArtigo JA 
				where JA.IdentificadorJurisprudencia in (

					Select PJ.IdentificadorJurisprudencia from PesquisaJurisprudencia PJ
						where PJ.IdentificadorPesquisa in (
						
							Select P.Identificador from Pesquisa P
								where P.Pesquisa = 'Tutela Medicamentos provisórios idosos'
						
						)

				)
		 )

		--Artigos citados na jurisprudencia (Select por Identificador) 
		Select A.NomeArtigo from Artigo A
		 where A.Identificador in (
		 
			Select JA.IdentificadorArtigo from JurisprudenciaArtigo JA 
				where JA.IdentificadorJurisprudencia in (

					Select J.Identificador from Jurisprudencia J
						where J.Identificador = 52

				)
		 )

		--Artigos da jurisprudencia (Select por NomeProcesso) 
		Select A.NomeArtigo from Artigo A
		 where A.Identificador in (
		 
			Select JA.IdentificadorArtigo from JurisprudenciaArtigo JA 
				where JA.IdentificadorJurisprudencia in (

					Select J.Identificador from Jurisprudencia J
						where J.Processo = ' '

				)
		 )


		 --Quantas jurisprudencias deferidas por pesquisa
		 Select count(J.Identificador) as QuantDeferidas from Jurisprudencia J
			where J.Identificador in (

				Select PJ.IdentificadorJurisprudencia from PesquisaJurisprudencia PJ
					where PJ.IdentificadorPesquisa in (

						Select P.Identificador from Pesquisa P
							where P.Pesquisa = 'Bloqueio de linhas telefônicas móveis'

					)
			
			) AND J.StatusJurisprudencia = 'DEFERIDA'

		 --Quantas jurisprudencias indeferidas por pesquisa
		Select count(J.Identificador) as QuantIndeferidas from Jurisprudencia J
			where J.Identificador in (

				Select PJ.IdentificadorJurisprudencia from PesquisaJurisprudencia PJ
					where PJ.IdentificadorPesquisa in (

						Select P.Identificador from Pesquisa P
							where P.Pesquisa = 'Bloqueio de linhas telefônicas móveis'

					)
			
			) AND J.StatusJurisprudencia = 'INDEFERIDA'

		--Quantas jurisprudencias parcialmente deferidas por pesquisa
		Select count(J.Identificador) as QuantParcialDeferidas from Jurisprudencia J
			where J.Identificador in (

				Select PJ.IdentificadorJurisprudencia from PesquisaJurisprudencia PJ
					where PJ.IdentificadorPesquisa in (

						Select P.Identificador from Pesquisa P
							where P.Pesquisa = 'Bloqueio de linhas telefônicas móveis'

					)
			
			) AND J.StatusJurisprudencia = 'PARCIALMENTE DEFERIDA'

		--Quantis jurisprudencias deferidas
		Select count(J.Identificador) as QuantParcialDeferidas from Jurisprudencia  J
			where J.StatusJurisprudencia = 'DEFERIDA'