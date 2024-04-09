namespace TCC_TutelaProvisoria
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarCaminhoDaPastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matheusPiresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.douglasTertulianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.CriaBOW = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.CheckedListTutelasLidas = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Histograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1349, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1349, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.pegarCaminhoDaPastaToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.abrirToolStripMenuItem.Text = "Selecionar arquivo Word";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // pegarCaminhoDaPastaToolStripMenuItem
            // 
            this.pegarCaminhoDaPastaToolStripMenuItem.Name = "pegarCaminhoDaPastaToolStripMenuItem";
            this.pegarCaminhoDaPastaToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.pegarCaminhoDaPastaToolStripMenuItem.Text = "Selecionar varios arquivos Word";
            this.pegarCaminhoDaPastaToolStripMenuItem.Click += new System.EventHandler(this.pegarCaminhoDaPastaToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoresToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // autoresToolStripMenuItem
            // 
            this.autoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matheusPiresToolStripMenuItem,
            this.douglasTertulianoToolStripMenuItem});
            this.autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            this.autoresToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.autoresToolStripMenuItem.Text = "Autores";
            // 
            // matheusPiresToolStripMenuItem
            // 
            this.matheusPiresToolStripMenuItem.Name = "matheusPiresToolStripMenuItem";
            this.matheusPiresToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.matheusPiresToolStripMenuItem.Text = "Matheus Pires";
            this.matheusPiresToolStripMenuItem.Click += new System.EventHandler(this.matheusPiresToolStripMenuItem_Click);
            // 
            // douglasTertulianoToolStripMenuItem
            // 
            this.douglasTertulianoToolStripMenuItem.Name = "douglasTertulianoToolStripMenuItem";
            this.douglasTertulianoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.douglasTertulianoToolStripMenuItem.Text = "Douglas Tertuliano";
            this.douglasTertulianoToolStripMenuItem.Click += new System.EventHandler(this.douglasTertulianoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(538, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "ANÁLISE DE TUTELA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CriaBOW
            // 
            this.CriaBOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CriaBOW.Location = new System.Drawing.Point(12, 66);
            this.CriaBOW.Name = "CriaBOW";
            this.CriaBOW.Size = new System.Drawing.Size(151, 56);
            this.CriaBOW.TabIndex = 4;
            this.CriaBOW.Text = "Cria a Bag of words";
            this.CriaBOW.UseVisualStyleBackColor = true;
            this.CriaBOW.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 145);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1073, 436);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(169, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "Analisa quant. de palavras em cada tutela";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(483, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 56);
            this.button2.TabIndex = 7;
            this.button2.Text = "Selecionar tutelas para comparar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(801, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1126, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "Tutelas já lidas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CheckedListTutelasLidas
            // 
            this.CheckedListTutelasLidas.CheckOnClick = true;
            this.CheckedListTutelasLidas.FormattingEnabled = true;
            this.CheckedListTutelasLidas.Location = new System.Drawing.Point(116, 187);
            this.CheckedListTutelasLidas.Name = "CheckedListTutelasLidas";
            this.CheckedListTutelasLidas.Size = new System.Drawing.Size(851, 394);
            this.CheckedListTutelasLidas.TabIndex = 11;
            this.CheckedListTutelasLidas.Visible = false;
            this.CheckedListTutelasLidas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListTutelasLidas_ItemCheck);
            this.CheckedListTutelasLidas.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(650, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 56);
            this.button4.TabIndex = 12;
            this.button4.Text = "Realizar similaridade entre tutelas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1227, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 24);
            this.button5.TabIndex = 13;
            this.button5.Text = "Limpar tutelas lidas";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(326, 66);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(151, 56);
            this.button6.TabIndex = 14;
            this.button6.Text = "Montar Histograma";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Histograma
            // 
            chartArea2.Name = "ChartArea1";
            this.Histograma.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Histograma.Legends.Add(legend2);
            this.Histograma.Location = new System.Drawing.Point(17, 178);
            this.Histograma.Name = "Histograma";
            this.Histograma.Size = new System.Drawing.Size(1278, 417);
            this.Histograma.TabIndex = 15;
            this.Histograma.Text = "Histograma";
            this.Histograma.Visible = false;
            this.Histograma.Click += new System.EventHandler(this.Histograma_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(985, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 41);
            this.button7.TabIndex = 16;
            this.button7.Text = "Carrega imagem para extrair texto";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(1219, 105);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(108, 43);
            this.button8.TabIndex = 17;
            this.button8.Text = "Busca jurisprudencia";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(942, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1349, 607);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Histograma);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.CheckedListTutelasLidas);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.CriaBOW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análise de Tutela";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem pegarCaminhoDaPastaToolStripMenuItem;
        private System.Windows.Forms.Button CriaBOW;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox CheckedListTutelasLidas;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataVisualization.Charting.Chart Histograma;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem autoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matheusPiresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem douglasTertulianoToolStripMenuItem;
    }
}

