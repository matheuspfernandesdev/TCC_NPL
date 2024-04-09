using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_TutelaProvisoria.Entities;

namespace TCC_TutelaProvisoria.DbConnect
{
    public abstract class JurisprudenciaDB
    {

        public static void SalvaPesquisaJurisprudenciaNoBanco(PesquisaJurisprudencia PJ)
        {
            int IdentificadorJurisprudencia = -1;
            int IdentificadorArtigo = -1;

            int IdentificadorPesquisa = BaseDB.RunScriptAndReturnIntValue(@"    DECLARE @IdPesquisa INT

                                                                                INSERT INTO [dbo].[Pesquisa]
                                                                                            ([Pesquisa])
                                                                                        VALUES
                                                                                            ('" + PJ.Pesquisa + "')" + 

                                                                                "SET @IdPesquisa = SCOPE_IDENTITY();" + 
                                                                                "SELECT @IdPesquisa ");

            foreach (Jurisprudencia jurisprudencia in PJ.Jurisprudencias)
            {
                IdentificadorJurisprudencia = SalvaJurisprudenciaNoBanco(jurisprudencia);

                BaseDB.RunSQLScript(@"  INSERT INTO[dbo].[PesquisaJurisprudencia]
                                                   ([IdentificadorPesquisa]
                                                   ,[IdentificadorJurisprudencia])
                                             VALUES
                                                   (" + IdentificadorPesquisa + " , " +
                                                        IdentificadorJurisprudencia + ")"       
                                   );

                foreach (var artigo in jurisprudencia.ListaArtigos)
                {
                    IdentificadorArtigo = BaseDB.RunScriptAndReturnIntValue(@"      DECLARE @IdArtigo INT

                                                                                    INSERT INTO [dbo].[Artigo]
                                                                                               ([NomeArtigo])
                                                                                         VALUES
                                                                                               ('" +  artigo + "') " +


                                                                                    "SET @IdArtigo = SCOPE_IDENTITY();" + 
                                                                                    "Select @IdArtigo ");

                    BaseDB.RunSQLScript(@"  INSERT INTO [dbo].[JurisprudenciaArtigo]
                                                   ([IdentificadorJurisprudencia]
                                                   ,[IdentificadorArtigo])
                                            VALUES
                                                (" + IdentificadorJurisprudencia + " , " +
                                                     IdentificadorArtigo + ")"
                   );


                }

            }
        }

        public static int SalvaJurisprudenciaNoBanco(Jurisprudencia J)
        {
           return BaseDB.RunScriptAndReturnIntValue(@"  DECLARE @IdJurisprudencia INT

                                                        INSERT INTO [dbo].[Jurisprudencia]
                                                                    ([Processo]
                                                                    ,[Relator]
                                                                    ,[OrgaoJulgador]
                                                                    ,[Sumula]
                                                                    ,[DataJulgamento]
                                                                    ,[DataPublicacao]
                                                                    ,[Ementa]
                                                                    ,[InteiroTeor]
                                                                    ,[StatusJurisprudencia])
                                                                VALUES
                                                                    ('" + J.Processo.Replace("'", "") + "', '" + 
                                                                            J.Relator.Replace("'", "") + "', '" + 
                                                                            J.OrgaoJulgador.Replace("'", "") + "', '" +
                                                                            J.Sumula.Replace("'", "") + "', '" + 
                                                                            J.DataJulgamento.Replace("'", "") + "', '" + 
                                                                            J.DataPublicacao.Replace("'", "") + "', '" +
                                                                            J.Ementa.Replace("'", "") + "', '" + 
                                                                            J.InteiroTeor.Replace("'", "") + "', '" + 
                                                                            J.StatusJurisprudencia + "');" + 
                                                                            " SET @IdJurisprudencia = SCOPE_IDENTITY() " + 
                                                                            " SELECT @IdJurisprudencia ");
        }

    }
}
