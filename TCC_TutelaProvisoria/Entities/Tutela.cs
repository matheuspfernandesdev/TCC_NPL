using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_TutelaProvisoria.Entities
{
    public class Tutela
    {
        public int MyProperty { get; set; }

        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Texto { get; set; }
        public bool Aprovada { get; set; }
        public Dictionary<string, int> QuantPalavrasDaBOW { get; set; }

        public Tutela(string nome, string caminho, string texto)
        {
            this.Nome = nome;
            this.Caminho = caminho;
            this.Texto = texto;
            QuantPalavrasDaBOW = new Dictionary<string, int>();
        }


        public Tutela()
        {
            QuantPalavrasDaBOW = new Dictionary<string, int>();
        }

    }
}
