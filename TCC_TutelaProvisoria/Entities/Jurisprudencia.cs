using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_TutelaProvisoria.Entities
{
    public class Jurisprudencia
    {
        public string Processo { get; set; }
        public string Relator { get; set; }
        public string OrgaoJulgador { get; set; }
        public string Sumula { get; set; }
        public string DataJulgamento { get; set; }
        public string DataPublicacao { get; set; }
        public string Ementa { get; set; }
        public string InteiroTeor { get; set; }
        public List<string> ListaArtigos { get; set; }
        public string StatusJurisprudencia { get; set; }

        public Jurisprudencia()
        {
            ListaArtigos = new List<string>();
        }

        public Jurisprudencia(string Processo, string Relator, string OrgaoJulgador, string Sumula, string DataJulgamento, string DataPublicacao, string Ementa, string InteiroTeor)
        {
            this.Processo = Processo;
            this.Relator = Relator;
            this.OrgaoJulgador = OrgaoJulgador;
            this.Sumula = Sumula;
            this.DataJulgamento = DataJulgamento;
            this.DataPublicacao = DataPublicacao;
            this.Ementa = Ementa;
            this.InteiroTeor = InteiroTeor;
            ListaArtigos = new List<string>();
        }

        public string ShowJurisprudencia()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var Artigo in ListaArtigos)
            {
                sb.Append(Artigo);
            }

            return "PROCESSO: " + Processo + "\n" +
                   "RELATOR: " + Relator + "\n" +
                   "ORGAO JULGADOR / CAMARA: " + OrgaoJulgador + "\n" +
                   "SUMULA: " + Sumula + "\n" +
                   "DATA DE JULGAMENTO: " + DataJulgamento + "\n" +
                   "DATA DE PUBLICACAO: " + DataPublicacao + "\n\n"
                   + "EMENTA: " + Ementa + "\n\n" +
                   "INTEIRO TEOR: " + InteiroTeor + "\n" +
                   "ARTIGOS ENCONTRADOS: " + sb.ToString ()
                   ; 
        }

        public void PreenchendoListaArtigos()
        {
            bool SaoArtigos = false;
            int CountArtigos = 0;
            StringBuilder sb = new StringBuilder();

            var PalavrasDaJuris = InteiroTeor.Split(' ');
            var PreviousWord = PalavrasDaJuris.ElementAt(0);

            foreach (var CurrentWord in PalavrasDaJuris)
            {
                if (SaoArtigos)
                {
                    if (CurrentWord.EndsWith(".") || CurrentWord.Equals(".") ||
                        CurrentWord.EndsWith(")") || CurrentWord.Equals(")") ||
                        CurrentWord.EndsWith(":") || CurrentWord.Equals(":") ||
                        CurrentWord.EndsWith(@"\") || CurrentWord.Equals(@"\") ||
                        CurrentWord.EndsWith("\"") || CurrentWord.Equals("\"") ||
                        CurrentWord.EndsWith("\n") || CurrentWord.EndsWith("\r") ||
                        CountArtigos > 8)                                                       //Precisa de um maximo, de ler 8 palavras após achar um "ARTIGOS"
                    {
                        sb.Append(CurrentWord);
                        SaoArtigos = false;
                        CountArtigos = 0;
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(CurrentWord);
                        CountArtigos++;
                    }
                }

                else
                {
                    if (PreviousWord.Contains("ARTIGOS") && Util.PalavraContemDigito(CurrentWord))  //Se a palavra anterior é "ARTIGOS" e a atual contem numeros
                    {
                        SaoArtigos = true;

                        sb.Append(CurrentWord);
                    }

                    else if (PreviousWord.Contains("ART.") || PreviousWord.Equals("ARTIGO") || (PreviousWord.Equals("ART")))
                    {
                        if (Util.PalavraContemDigito(CurrentWord))             //Só adicionará a lista de artigos caso a palavra posterior contenha um numero (Ex: Art. 23)
                        {
                            ListaArtigos.Add(CurrentWord);
                        }
                    }
                    else if (CurrentWord.StartsWith("ARTS.") || CurrentWord.StartsWith("ART.") || CurrentWord.StartsWith("art.") || CurrentWord.StartsWith("arts."))
                    {
                        if (Util.PalavraContemDigito(CurrentWord))             //Só adicionará a lista de artigos caso a palavra posterior contenha um numero (Ex: Art. 23)
                        {
                            ListaArtigos.Add(CurrentWord);
                        }
                    }
                }

                PreviousWord = CurrentWord.ToUpper();
            }

            NormalizaArtigos();
            
        }

        public void NormalizaArtigos()          //Normalizar para deixar somente números
        {
            List<string> NewListaArtigos = new List<string>();
            StringBuilder sb;

            for (int i = 0; i < this.ListaArtigos.Count; i++)
            {
                sb = new StringBuilder();

                if (!Util.PalavraContemDigito(this.ListaArtigos.ElementAt(i)))
                    ListaArtigos.RemoveAt(i);

                else
                {
                    foreach (char c in this.ListaArtigos.ElementAt(i))
                    {
                        if (char.IsDigit(c) || c.Equals('-'))
                        {
                            sb.Append(c);
                        }
                    }
                }

                NewListaArtigos.Add(sb.ToString());

            }

            this.ListaArtigos = NewListaArtigos;

        }

        public void PreencheStatusJurisprudencia()
        {
            if (!String.IsNullOrEmpty(this.Sumula))
            {

                if (this.Sumula.ToUpper().Contains("NEGARAM PROVIMENTO") ||
                    this.Sumula.ToUpper().Contains("NEGO PROVIMENTO") ||
                    this.Sumula.ToUpper().Contains("RECURSO NÃO PROVIDO") ||
                    this.Sumula.ToUpper().Contains("NEGAR PROVIMENTO"))

                            this.StatusJurisprudencia = "INDEFERIDA";

                else if (this.Sumula.ToUpper().Contains("REFORMO PARCIALMENTE") ||
                         this.Sumula.ToUpper().Contains("DERAM PROVIMENTO EM PARTE") ||
                         this.Sumula.ToUpper().Contains("DERAM PARCIAL PROVIMENTO") ||
                         this.Sumula.ToUpper().Contains("PROVIDO EM PARTE") ||
                         this.Sumula.ToUpper().Contains("DERAM PROVIMENTO PARCIAL"))
                         
                            this.StatusJurisprudencia = "PARCIALMENTE DEFERIDA";

                else if (this.Sumula.ToUpper().Contains("RECURSO PROVIDO") ||
                         this.Sumula.ToUpper().Contains("DERAM PROVIMENTO"))

                             this.StatusJurisprudencia = "DEFERIDA";

                else 

                    this.StatusJurisprudencia = "SETENÇA REFORMADA";

            }
        }

    }
}
