using Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC_TutelaProvisoria.WebCrawler.PageObject
{
    public abstract class TJMG_PageObject : DriverFactory
    {   
        public void BuscarJurisprudencia(string Pesquisa)
        {
            PreencheCampo(Pesquisa, By.Id("palavras"));
            ClicaBotao(By.XPath("//*[@id='acordao-form']/div[2]/button"));
            EsperaPorElementosLocalizadosPor(By.ClassName("caixa_processo"), 15);
        }

        public void ClicaNaPrimeiraJurisprudencia()
        {
            ClicaBotao(By.XPath("//*[@class='caixa_processo'][1]/a"));
            EsperaPorElementoVisivel(By.Id("textoUmaColuna"));
        }

        public int ObterQuantJurisprudencias()
        {
            EsperaPorElementoVisivel(By.XPath("//*[@id='textoUmaColuna']/table[1]/tbody/tr[1]/td"));
            var Encontrados = driver.FindElement(By.XPath("//*[@id='textoUmaColuna']/table[1]/tbody/tr[1]/td")).Text;

            int pFrom = Encontrados.IndexOf("de ") + "de ".Length;
            int pTo = Encontrados.LastIndexOf("encontrados");

            string NumPags = Encontrados.Substring(pFrom, pTo - pFrom);

            return Convert.ToInt32(NumPags);
        }

        public void IrParaProximaPagina()
        {
            ClicaBotao(By.XPath("//tbody//table//td[5]"));
            Thread.Sleep(3000);
        }

        public string ObterProcesso()
        {
            return driver.FindElement(By.XPath("//*[@class='cabecalho' and contains(.,'Processo')]/following-sibling::div[1]")).Text;
        }

        public string ObterRelator()
        {
            return driver.FindElement(By.XPath("//*[@class='cabecalho' and contains(.,'Relator(a)')]/following-sibling::div[1]")).Text;
        }

        public string ObterOrgaoJulgador()
        {
            return driver.FindElement(By.XPath("//*[@class='cabecalho' and contains(.,'Órgão Julgador')]/following-sibling::div[1]")).Text;
        }

        public string ObterSumula()
        {
            return driver.FindElement(By.XPath("//*[@class='cabecalho' and contains(.,'Súmula')]/following-sibling::div[1]")).Text;
        }

        public string ObterDataJulgamento()
        {
            return driver.FindElement(By.XPath("//*[@class='cabecalho' and contains(.,'Data de Julgamento')]/following-sibling::div[1]")).Text;
        }

        public string ObterDataPublicacao()
        {
            return driver.FindElement(By.XPath("//*[@class='cabecalho' and contains(.,'Data da publicação')]/following-sibling::div[1]")).Text;
        }

        public string ObterEmenta()
        {
            return driver.FindElement(By.Id("ementa")).Text;
        }

        public string ObterInteiroTeor()
        {
            try
            {
                //if (IsElementPresent(By.XPath("//*[@class='cabecalho' and contains(.,'Inteiro Teor')]")))
                //{
                    ClicaBotao(By.Id("imgBotao1"));
                    //MessageBox.Show("Clicou no botao do Inteiro Teor");
                    Thread.Sleep(2000);
                //if (IsElementPresent(By.XPath("//*[@id='panel1']/div[2]")))
                    return driver.FindElement(By.XPath("//*[@id='panel1']/div[2]")).Text;
                //else
                    //return "empty";
                //}
                //else
                    //return "empty";
            }
            catch (Exception)
            {
                return "empty";
            }
        }

    }
}
