using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Data.SqlClient;
using static System.Windows.Forms.CheckedListBox;
using TCC_TutelaProvisoria.Recursos;
using System.Windows.Forms.DataVisualization.Charting;
using TCC_TutelaProvisoria.WebCrawler.Acesso;
using TCC_TutelaProvisoria.Entities;
using TCC_TutelaProvisoria.DbConnect;

namespace TCC_TutelaProvisoria
{
    public partial class Form1 : Form
    {
        //public Word.Application wordDoc;
        public Word.Document doc;
        public StringBuilder data = new StringBuilder();
        string CaminhoDaPasta;
        string CaminhoDoDocumento;
        string[] CaminhosDosDocumentos;
        List<string> ListaDeDocumentos;
        List<string> BagOfWords;
        public PesquisaJurisprudencia v_PesquisaJurisprudencia; 

        Tutela tutela = new Tutela();
        List<Tutela> G_ListaDeTutelas = new List<Tutela>();

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = false;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Open the Word file: ",
                DefaultExt = "docx",
                Filter = "docx files(*.docx)|*.docx|doc files(*.doc)|*.doc|All files(*.*)|*.*"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CaminhoDoDocumento = openFileDialog1.FileName;

                //wordDoc = new Word.Application();
                //wordDoc.Visible = true;           //Abre o arquivo no pc quando der o Open
                doc = Util.GerarInstanciaDocumento(CaminhoDoDocumento);

            }

            if (doc != null)
            {
                string TextoTutela = Util.RetornaOTextoDeUmArquivoDocx(doc, data);
                tutela = new Tutela(Path.GetFileName(CaminhoDoDocumento), CaminhoDoDocumento, TextoTutela);

                G_ListaDeTutelas.Add(tutela);
                TutelaDB.SalvaTutelaNoBanco(tutela);
                MessageBox.Show(TextoTutela);
            }
        }

        private void pegarCaminhoDaPastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = false;

            ListaDeDocumentos = new List<string>();
            var L_ListaDeTutelas = new List<Tutela>();

            FolderBrowserDialog folderDialog = new FolderBrowserDialog
            {
                Description = "To get a folder path: "
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
                CaminhoDaPasta = folderDialog.SelectedPath;

            //MessageBox.Show("Caminho da pasta: " + CaminhoDaPasta);

            CaminhosDosDocumentos = Util.RetornaTodosOsCaminhosDeArquivosBaseadoNumaPasta(CaminhoDaPasta);

            if (CaminhosDosDocumentos != null)
            {
                L_ListaDeTutelas = Util.RetornaTodosOsTextosDeArquivosDocx(CaminhosDosDocumentos);

                foreach (Tutela tutela in L_ListaDeTutelas)
                {
                    G_ListaDeTutelas.Add(tutela);
                }

                TutelaDB.SalvaNoBancoTodasAsTutelasLidas(L_ListaDeTutelas);

                //PRINTA TODOS ARQUIVOS ENCONTRADOS DENTRO DA PASTA
                //foreach (Tutela tutela in ListaDeTutelas)
                //{
                //    MessageBox.Show(tutela.Texto);
                //}

                MessageBox.Show(String.Format(MensagensSistema.LeuTodasTutelas) + L_ListaDeTutelas.Count);
            }
            else
            {
                MessageBox.Show(MensagensSistema.PastaVazia);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = false;

            if (G_ListaDeTutelas != null)
            {
                richTextBox1.Clear();

                BagOfWords = new List<string>();
                BagOfWords = Util.RetornaBagOfWords(G_ListaDeTutelas);

                MessageBox.Show(MensagensSistema.QuantidadePalavrasEncontradas + BagOfWords.Count);

                richTextBox1.Show();

                foreach (string palavra in BagOfWords)
                {
                    richTextBox1.AppendText(palavra + "\n");
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = false;

            if (G_ListaDeTutelas != null && BagOfWords != null)
            {
                string relatorio = Util.QuantidadePalavrasPorTutela(G_ListaDeTutelas, BagOfWords);

                richTextBox1.Clear();
                richTextBox1.AppendText(relatorio);
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            CheckedListTutelasLidas.Visible = true;
            Histograma.Visible = false;

            var Itens = CheckedListTutelasLidas.Items;
            Itens.Clear();

            foreach (Tutela tutela in G_ListaDeTutelas)
            {
                Itens.Add(tutela.Nome);
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = false;
            richTextBox1.Clear();

            richTextBox1.AppendText(MensagensSistema.QuantidadeTutelasLidas + G_ListaDeTutelas.Count + "\n\n");

            if (G_ListaDeTutelas.Count > 0)
            {
                richTextBox1.AppendText("TUTELAS\n\n");

                foreach (Tutela tutela in G_ListaDeTutelas)
                {
                    richTextBox1.AppendText(tutela.Nome + "\n");
                }
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = false;
            List<string> NomesDasTutelasQueSeraoAnalisadas = new List<string>();
            List<Tutela> TutelasQueSeraoAnalisadas = new List<Tutela>();

            CheckedItemCollection ItemsMarcados;
            ItemsMarcados = CheckedListTutelasLidas.CheckedItems;

            if (ItemsMarcados.Count > 2)
                MessageBox.Show("Deve selecionar apenas 2 tutelas");

            else
            {
                foreach (var item in ItemsMarcados)
                {
                    NomesDasTutelasQueSeraoAnalisadas.Add(item.ToString());
                }

                foreach (Tutela tutela in G_ListaDeTutelas)
                {

                    foreach (string NomeTutela in NomesDasTutelasQueSeraoAnalisadas)
                    {

                        if (tutela.Nome.Equals(NomeTutela))
                        {
                            TutelasQueSeraoAnalisadas.Add(tutela);
                            break;                                      //Vai sempre pegar o primeiro nome que achar. Esse é o problema de ter tutelas com nomes repetidos. Tinha que tratar com Identificador
                        }
                    }
                }

                if (TutelasQueSeraoAnalisadas.Count > 0)
                {
                    double Similaridade = Util.RealizaSimilaridade(TutelasQueSeraoAnalisadas.ElementAt(0), TutelasQueSeraoAnalisadas.ElementAt(1));
                    MessageBox.Show(MensagensSistema.PorcentagemSimilaridade + Similaridade * 100 + "%");
                }
                else
                {
                    MessageBox.Show(MensagensSistema.SelecionarDois);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int QuantTutelas = G_ListaDeTutelas.Count;
            Histograma.Visible = false;

            G_ListaDeTutelas.Clear();

            //MessageBox.Show("Tutelas excluídas com sucesso! \n" + QuantTutelas + " tutelas foram excluídas.");
            MessageBox.Show(String.Format(MensagensSistema.TutelasExcluidasSuccess, QuantTutelas));
        }

        private void CheckedListTutelasLidas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && CheckedListTutelasLidas.CheckedItems.Count >= 2)
                e.NewValue = CheckState.Unchecked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckedListTutelasLidas.Visible = false;
            Histograma.Visible = true;
            richTextBox1.Clear();

            try
            {
                Histograma.Titles.Clear();
                Histograma.Titles.Add("Histograma das tutelas");

                foreach (Tutela tutela in G_ListaDeTutelas)
                {
                    Histograma.Series.Add(tutela.Nome);
                }


                foreach (Series serie in Histograma.Series)
                {
                    foreach (string palavraAnalisada in BagOfWords)
                    {
                        serie.Points.AddXY(palavraAnalisada, G_ListaDeTutelas.First(s => s.Nome.Equals(serie.Name)).QuantPalavrasDaBOW[palavraAnalisada]);
                    }
                }


                //foreach (Tutela tutela in G_ListaDeTutelas)
                //{

                //}

            }

            catch (Exception ex)
            {
                MessageBox.Show(MensagensSistema.ErroPadrao + "\n\n" + ex.Message);
            }




            //Histograma.Series.Add("s1");
            //Histograma.Series["s1"].Points.AddXY("Day1", "100");

            //foreach (Tutela tutela in G_ListaDeTutelas)
            //{
            //    Histograma.Series.Add(tutela.Nome);
            //    Histograma.Series[tutela.Nome].Points.AddXY(tutela.Nome, "100");
            //}
        }

        private void Histograma_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog
            //{
            //    Title = "Escolha uma imagem: ",
            //    DefaultExt = "png",
            //    Filter = "png files(*.png)|*.png|bitmap files(*.bmp)|*.bmp|All files(*.*)|*.*"
            //};

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string TextoDaImagem = Util.RetornaTextoDeUmaImagem(openFileDialog1.FileName);
            //    richTextBox1.Clear();           richTextBox1.AppendText(TextoDaImagem);
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //conjuge alimentos provisorios posse bens              4 resultados
            //união parcial bens alimentos provisórios              16 resultados
            //Tutela alimentos provisórios separação                  18 resultados
            //tutela provisoria alimentos conjuge                   23 resultados

            var Pesquisa = textBox1.Text;
            richTextBox1.Clear();
            textBox1.Clear();

            TJMG_Acesso TJ = new TJMG_Acesso();
            v_PesquisaJurisprudencia = new PesquisaJurisprudencia();
            v_PesquisaJurisprudencia = TJ.AcessarTJMG(Pesquisa);
            v_PesquisaJurisprudencia.PreenchendoListaArtigosPorJurisprudencia();

            richTextBox1.AppendText(v_PesquisaJurisprudencia.ShowPesquisa() + "\n\n\n ---------------------------------------------------------- \n\n");
            JurisprudenciaDB.SalvaPesquisaJurisprudenciaNoBanco(v_PesquisaJurisprudencia);

            MessageBox.Show(MensagensSistema.BuscaJurisprudenciaFinalizada);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var a = BaseDB.RunScriptAndReturnIntValue(@"       DECLARE @IdPesquisa INT

                                                    INSERT INTO [dbo].[Pesquisa]
                                                               ([Pesquisa])
                                                         VALUES
                                                               ('Pesquisa 1')

                                                    SET @IdPesquisa = SCOPE_IDENTITY();
                                                    SELECT @IdPesquisa
                                                        ");

            MessageBox.Show("" + a);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void matheusPiresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MatheusMets");
        }

        private void douglasTertulianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://douglasjtds.github.io");
        }
    }
}
