using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.Globalization;
using TCC_TutelaProvisoria.Recursos;
using System.Drawing;
using TCC_TutelaProvisoria.Entities;
//using Tesseract;

namespace TCC_TutelaProvisoria
{
    public static class Util
    {

        #region [Manipulacao arquivo word]

        public static string[] RetornaTodosOsCaminhosDeArquivosBaseadoNumaPasta(string CaminhoDaPasta)
        {
            string[] DocPaths;

            if (!String.IsNullOrEmpty(CaminhoDaPasta) && Directory.GetFiles(CaminhoDaPasta).Length > 0)          //Se ele nao for nula nem vazia, pega o caminho de cada arquivo
            {
                DocPaths = new string[Directory.GetFiles(CaminhoDaPasta).Length - 1];
                DocPaths = Directory.GetFiles(CaminhoDaPasta);
                return DocPaths;
            }
            else
            {
                return null;
            }
        }

        public static void SelectionFind(Word.Application Doc, object findText)
        {
            Doc.Selection.Find.ClearFormatting();

            object missing = null;

            if (Doc.Selection.Find.Execute(ref findText,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing))
            {
                MessageBox.Show("Texto encontrado!");
            }
            else
            {
                MessageBox.Show("Texto não localizado");
            }
        }

        public static bool IsArquivoWord(string CaminhoDoDocumento)
        {
            if (CaminhoDoDocumento.EndsWith(".docx") ||
                CaminhoDoDocumento.EndsWith(".doc") ||
                CaminhoDoDocumento.EndsWith(".dot") ||
                CaminhoDoDocumento.EndsWith(".dotx") ||
                CaminhoDoDocumento.EndsWith(".dotm"))
            
                    return true;
            
            else
                return false;
            

        }

        public static Word.Document GerarInstanciaDocumento(string CaminhoDoDocumento)
        {
            if (IsArquivoWord(CaminhoDoDocumento))
            {
                Word.Application wordDoc = new Word.Application();
                Word.Document doc = wordDoc.Documents.Open(CaminhoDoDocumento, ReadOnly: true, Visible: false);

                return doc;
            }

            return null;

        }

        public static string RetornaOTextoDeUmArquivoDocx(Word.Document Doc, StringBuilder TextoDoArquivo)
        {
            try
            {
                TextoDoArquivo = new StringBuilder();

                for (int i = 0; i < Doc.Paragraphs.Count; i++)
                {
                    string temp = Doc.Paragraphs[i + 1].Range.Text.Trim();
                    if (temp != string.Empty)
                    {
                        TextoDoArquivo.Append(temp);
                        TextoDoArquivo.Append(" ");
                    }
                }

                Doc.Close();
                return TextoDoArquivo.ToString();
            }

            catch (Exception)
            {
                MessageBox.Show(MensagensSistema.CarregueAlgumArquivo);
                return null;
            }

            //return Doc.Selection.Find.Text;
        }

        public static List<Tutela> RetornaTodosOsTextosDeArquivosDocx(string[] CaminhosDosDocumentos)
        {
            Tutela tutela = new Tutela();
            List<Tutela> ListaDeTutelas = new List<Tutela>();

            foreach (string caminho in CaminhosDosDocumentos)
            {
                if (Util.IsArquivoWord(caminho))
                {
                    tutela = new Tutela
                    {
                        Caminho = caminho,
                        Nome = Path.GetFileName(caminho)
                    };

                    ListaDeTutelas.Add(tutela);

                    //MessageBox.Show(caminho);
                }
            }

            Word.Document doc;
            StringBuilder data = new StringBuilder();

            foreach (Tutela T in ListaDeTutelas)
            {
                doc = Util.GerarInstanciaDocumento(T.Caminho);

                if (doc != null)
                    T.Texto = RetornaOTextoDeUmArquivoDocx(doc, data);
            }

            return ListaDeTutelas;
        }

        #endregion


        #region [Bag of words + Similaridade]

        public static List<string> RetornaBagOfWords(List<Tutela> ListaDeTutelas)
        {

            List<string> TodasAsPalavrasDoBagOfWords = new List<string>();
            List<string> PalavrasDeUmaTutela = new List<string>();
            string PalavraParaEntrarNoBagOfWords;
            bool JaEstaNaBagOfWords = false;

            foreach (Tutela tutela in ListaDeTutelas)                                                       //Verifica todas as string que tem textos de tutelas
            {
                PalavrasDeUmaTutela.Clear();

                PalavrasDeUmaTutela = tutela.Texto.Split(' ').ToList();

                foreach (string PalavraParaEntrarNoBagOfWordsBase in PalavrasDeUmaTutela)                   //Verifica todas as palavras dentro de uma tutela lida
                {
                    JaEstaNaBagOfWords = false;
                    PalavraParaEntrarNoBagOfWords = RemovePontuacaoDaPalavra(PalavraParaEntrarNoBagOfWordsBase);        //Retirando a pontuacao das palavras

                    if (TodasAsPalavrasDoBagOfWords.Count == 0)
                    {
                        TodasAsPalavrasDoBagOfWords.Add(PalavraParaEntrarNoBagOfWords.ToUpper());            //Todas as palavras devem ser adicionadas em LowerCase
                    }
                    else
                    {
                        string PalavraFinalParaEntrarNoBOW = RemoveAcentuacao(PalavraParaEntrarNoBagOfWords);

                        foreach (string PalavraDoBagOfWords in TodasAsPalavrasDoBagOfWords)                  //Verifica se palavra ja esta na bag of words
                        {
                            if (PalavraFinalParaEntrarNoBOW.ToUpper().Equals(PalavraDoBagOfWords))
                            {
                                JaEstaNaBagOfWords = true;
                                break;
                            }
                        }

                        if (!JaEstaNaBagOfWords && 
                            !String.IsNullOrEmpty(PalavraFinalParaEntrarNoBOW) && 
                            !PalavraContemDigito(PalavraFinalParaEntrarNoBOW) &&
                            PalavraFinalParaEntrarNoBOW.Length > 1)                   //Se a palavra não está na bag of words, adiciona
                        {
                            TodasAsPalavrasDoBagOfWords.Add(PalavraFinalParaEntrarNoBOW.ToUpper());
                        }

                    }

                }
            }

            return TodasAsPalavrasDoBagOfWords;
        }

        public static string QuantidadePalavrasPorTutela(List<Tutela> ListaDeTutelas, List<string> BagOfWords)
        {
            List<string> PalavrasDeUmaTutelaTemp = new List<string>();
            List<string> PalavrasDeUmaTutela = new List<string>();
            StringBuilder Relatorio = new StringBuilder();
            int CountPalavraAtualDaTutela;
            string NomeTutelaAtual = String.Empty;
            bool EstaNaTutelaBOW, IsTutelaNova = false;

            Relatorio.Append("RELATORIO: QUANTIDADE DE PALAVRAS QUE SE REPETEM POR TUTELA\nQuantida de palavras sendo analisadas: " + BagOfWords.Count + "\n\n");

            foreach (Tutela tutela in ListaDeTutelas)
            {
                IsTutelaNova = false;

                if (tutela.QuantPalavrasDaBOW == null)
                {
                    IsTutelaNova = true;
                    tutela.QuantPalavrasDaBOW = new Dictionary<string, int>();
                }

                Relatorio.Append("/******  TUTELA SENDO ANALISADA: \"" + tutela.Nome + "\"  ******/ \n");

                foreach (string PalavraBagOfWords in BagOfWords)
                {
                    EstaNaTutelaBOW = false;
                    CountPalavraAtualDaTutela = 0;

                    PalavrasDeUmaTutelaTemp = tutela.Texto.Split(' ').ToList();
                    PalavrasDeUmaTutelaTemp = PalavrasDeUmaTutelaTemp.ConvertAll(d => d.ToUpper());
                    PalavrasDeUmaTutela = RemovePontuacaoDeUmaListaDeString(PalavrasDeUmaTutelaTemp);

                    foreach (string palavra in PalavrasDeUmaTutela)
                    {
                        if (palavra.Equals(PalavraBagOfWords))
                            CountPalavraAtualDaTutela++;
                    }


                    if (IsTutelaNova)       //Se for uma tutela nova, só adiciona todas as palavras da Bag Of Words
                    {
                        tutela.QuantPalavrasDaBOW.Add(PalavraBagOfWords, CountPalavraAtualDaTutela);
                    }
                    else                    //Se nao for, verifica se a palavra atual já tem na TutelaBOW. Só adiciona se nao tiver.
                    {
                        foreach (string word in tutela.QuantPalavrasDaBOW.Keys)
                        {
                            if (PalavraBagOfWords.Equals(word))
                            {
                                EstaNaTutelaBOW = true;
                                break;
                            }
                        }

                        if (!EstaNaTutelaBOW)
                            tutela.QuantPalavrasDaBOW.Add(PalavraBagOfWords, CountPalavraAtualDaTutela);

                    }

                    NomeTutelaAtual = tutela.Nome;
                    Relatorio.Append("Palavra \"" + PalavraBagOfWords + "\" foi encontrada " + CountPalavraAtualDaTutela + " vezes na tutela \"" + NomeTutelaAtual + "\"\n");

                }


                Relatorio.Append("\n\n");
            }

            return Relatorio.ToString();

        }

        //public static string QuantidadePalavrasPorTutela(List<Tutela> ListaDeTutelas, List<string> BagOfWords)
        //{
        //    List<string> PalavrasDeUmaTutelaTemp = new List<string>();
        //    List<string> PalavrasDeUmaTutela = new List<string>();
        //    StringBuilder Relatorio = new StringBuilder();
        //    int Count;
        //    string NomeTutelaAtual = String.Empty;
        //    bool EstaNaTutelaBOW, IsTutelaNova = false;

        //    Relatorio.Append("RELATORIO: QUANTIDADE DE PALAVRAS QUE SE REPETEM POR TUTELA\nQuantida de palavras sendo analisadas: " + BagOfWords.Count + "\n\n");

        //    foreach (string PalavraBagOfWords in BagOfWords)
        //    {
        //        Relatorio.Append("/******  PALAVRA SENDO ANALISADA: \"" + PalavraBagOfWords + "\"  ******/ \n");

        //        foreach (Tutela tutela in ListaDeTutelas)
        //        {
        //            EstaNaTutelaBOW = false;
        //            IsTutelaNova = false;

        //            if (tutela.QuantPalavrasDaBOW == null)
        //            {
        //                IsTutelaNova = true;
        //                tutela.QuantPalavrasDaBOW = new Dictionary<string, int>();
        //            }


        //            Count = 0;

        //            PalavrasDeUmaTutelaTemp = tutela.Texto.Split(' ').ToList();
        //            PalavrasDeUmaTutelaTemp = PalavrasDeUmaTutelaTemp.ConvertAll(d => d.ToUpper());
        //            PalavrasDeUmaTutela = RemovePontuacaoDeUmaListaDeString(PalavrasDeUmaTutelaTemp);

        //            foreach (string palavra in PalavrasDeUmaTutela)
        //            {
        //                if (palavra.Equals(PalavraBagOfWords))
        //                    Count++;
        //            }



        //            if (IsTutelaNova)
        //            {
        //                tutela.QuantPalavrasDaBOW.Add(PalavraBagOfWords, Count);
        //            }
        //            else
        //            {
        //                foreach (string word in tutela.QuantPalavrasDaBOW.Keys)
        //                {
        //                    if (PalavraBagOfWords.Equals(word))
        //                    {
        //                        EstaNaTutelaBOW = true;
        //                        break;
        //                    }
        //                }

        //                if (EstaNaTutelaBOW)
        //                {
        //                    tutela.QuantPalavrasDaBOW[PalavraBagOfWords] = Count;
        //                }
        //                else
        //                {
        //                    tutela.QuantPalavrasDaBOW.Add(PalavraBagOfWords, Count);
        //                }
        //            }

        //            NomeTutelaAtual = tutela.Nome;
        //            Relatorio.Append("Palavra \"" + PalavraBagOfWords + "\" foi encontrada " + Count + " vezes na tutela \"" + NomeTutelaAtual + "\"\n");

        //        }


        //        Relatorio.Append("\n\n");
        //    }

        //    return Relatorio.ToString();

        //}

        public static double RealizaSimilaridade(Tutela tutela1, Tutela tutela2)
        {
            double Denominador = 0, Similaridade = 0, Raiz1 = 0, Raiz2 = 0;
            int Numerador = 0;

            var BOW = tutela1.QuantPalavrasDaBOW.Keys.ToList();

            foreach (string PalavraDoBOW in BOW)
            {
                Numerador += tutela1.QuantPalavrasDaBOW[PalavraDoBOW] * tutela2.QuantPalavrasDaBOW[PalavraDoBOW];
            }
            
            foreach (int value in tutela1.QuantPalavrasDaBOW.Values)
            {
                Raiz1 += Math.Pow(value, 2);
            }

            foreach (int value in tutela2.QuantPalavrasDaBOW.Values)
            {
                Raiz2 += Math.Pow(value, 2);
            }

            Denominador = Math.Sqrt(Raiz1) + Math.Sqrt(Raiz2);
            Similaridade = Numerador / Denominador;

            return Similaridade;
        }

        #endregion


        #region [Formatacao de string]

        public static List<string> RemovePontuacaoDeUmaListaDeString(List<string> PalavrasDeUmaTutela)
        {
            List<string> PalavrasDeUmaTutelaTemp = new List<string>();

            foreach (string PalavraTemp in PalavrasDeUmaTutela)
            {
                var NovaPalavra = RemovePontuacaoDaPalavra(PalavraTemp);

                if (!String.IsNullOrWhiteSpace(NovaPalavra.ToString()))
                {
                    PalavrasDeUmaTutelaTemp.Add(NovaPalavra.ToString());
                }

            }

            return PalavrasDeUmaTutelaTemp;
        }

        public static string RemovePontuacaoDaPalavra(string palavra)
        {
            var NovaPalavra = new StringBuilder();

            foreach (char c in palavra)
            {
                if (!char.IsPunctuation(c) && !char.IsSymbol(c) && !char.IsWhiteSpace(c))
                    NovaPalavra.Append(c);
            }

            return NovaPalavra.ToString();
        }

        public static string RemoveAcentuacao(string palavra)
        {
            //var normalizedString = palavra.Normalize(NormalizationForm.FormD);
            //var stringBuilder = new StringBuilder();

            //foreach (var c in normalizedString)
            //{
            //    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

            //    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            //        stringBuilder.Append(c);
            //}

            //return stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            if (!string.IsNullOrEmpty(palavra))
            {
                Encoding encoding = Encoding.GetEncoding("iso-8859-8");
                byte[] buffer = encoding.GetBytes(palavra);
                palavra = encoding.GetString(buffer);
            }


            return palavra;

        }

        public static bool PalavraContemDigito(string palavra)
        {
            var ContemDigito = false;

            foreach (char c in palavra)
            {
                if (char.IsDigit(c))
                {
                    ContemDigito = true;
                    break;
                }
            }

            return ContemDigito;
        }

        #endregion


        #region [Leitura de imagem]

        //public static string RetornaTextoDeUmaImagem(string CaminhoDaImagem)
        //{
        //    var pix = Pix.LoadFromFile(CaminhoDaImagem);
        //    var CaminhoDoTessData = Path.GetFullPath(@"..\..\tessdata");

        //    try
        //    {
        //        var OCR = new TesseractEngine(CaminhoDoTessData, "por", EngineMode.Default);
        //        var Page = OCR.Process(pix);
                
        //        return Page.GetText() + "\n\n" + "\nTaxa de precisao: " + Page.GetMeanConfidence();
        //    }
        //    catch (Exception e)
        //    {
        //        return "Erro: nao foi possivel retornar o texto da imagem. Erro encontrado: " + e.Message;
        //    }
        //}

        //public static string RetornaTextoDeUmaImagem2(string CaminhoDaImagem)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var client = GCV.ImageAnnotatorClient.Create();
        //    var image = GCV.Image.FromFile(CaminhoDaImagem);
        //    var response = client.DetectLabels(image);

        //    //var response = client.DetectFaces(image);

        //    foreach (var annotation in response)
        //    {
        //        if (annotation.Description != null)
        //            sb.Append(annotation.Description);
        //    }

        //    return sb.ToString();
        //}

        #endregion

    }
}
