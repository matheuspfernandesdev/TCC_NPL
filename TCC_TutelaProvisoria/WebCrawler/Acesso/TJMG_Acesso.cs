using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_TutelaProvisoria.Entities;
using TCC_TutelaProvisoria.WebCrawler.PageObject;

namespace TCC_TutelaProvisoria.WebCrawler.Acesso
{
    public class TJMG_Acesso : TJMG_PageObject
    {
        PesquisaJurisprudencia pesquisaJurisprudencia;
        Jurisprudencia jurisprudencia;

        public PesquisaJurisprudencia AcessarTJMG(string PesquisaASerFeita)
        {
            int QuantJurisprudenciasObtidas = 0;
            int QuantJurisprudenciasEncontradas = 0;
            pesquisaJurisprudencia = new PesquisaJurisprudencia();

            try
            {
                InicializaBrowserAnonimo("http://www.tjmg.jus.br/portal-tjmg/");
                BuscarJurisprudencia(PesquisaASerFeita);         pesquisaJurisprudencia.Pesquisa = PesquisaASerFeita;
                ClicaNaPrimeiraJurisprudencia();

                QuantJurisprudenciasEncontradas = ObterQuantJurisprudencias();

                for(QuantJurisprudenciasObtidas = 0; QuantJurisprudenciasObtidas < QuantJurisprudenciasEncontradas; QuantJurisprudenciasObtidas++)
                {
                    jurisprudencia = new Jurisprudencia
                    {
                        Processo = ObterProcesso(),
                        Relator = ObterRelator(),
                        Sumula = ObterSumula(),
                        OrgaoJulgador = ObterOrgaoJulgador(),
                        DataJulgamento = ObterDataJulgamento(),
                        DataPublicacao = ObterDataPublicacao(),
                        Ementa = ObterEmenta(),
                        InteiroTeor = ObterInteiroTeor()
                    };

                    pesquisaJurisprudencia.Jurisprudencias.Add(jurisprudencia);
                    IrParaProximaPagina();
                }
                
                return pesquisaJurisprudencia;
            }
            catch (NoAlertPresentException)
            {
                return pesquisaJurisprudencia;
            }
            catch (Exception ex)
            {
                TirarPrint();
                MessageBox.Show("ERRO: \n\n" + ex.Message);

                return pesquisaJurisprudencia;
            }
            finally
            {
                FinalizaNavegador();
            }

        }
    }
}
