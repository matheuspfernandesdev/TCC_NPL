using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace TCC_TutelaProvisoria
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //CreateIconInWordDoc();
        }

        static void CreateIconInWordDoc()
        {
            var wordDocument = new Word.Application();

            wordDocument.Visible = true;

            wordDocument.Documents.Add();

            wordDocument.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }
    }
}
