using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_TutelaProvisoria.Entities;

namespace TCC_TutelaProvisoria.DbConnect
{
    public abstract class TutelaDB
    {

        public static void SalvaTutelaNoBanco(Tutela tutela)
        {
            BaseDB.RunSQLScript(@"INSERT INTO Tutela
                              VALUES('" +
                                    tutela.Nome + "', '" +
                                    tutela.Caminho + "', '" +
                                    tutela.Texto + "',  " +
                        "NULL);"
                     );
        }

        public static void SalvaNoBancoTodasAsTutelasLidas(List<Tutela> p_ListaDeTutela)
        {

            foreach (Tutela tutela in p_ListaDeTutela)
            {
                SalvaTutelaNoBanco(tutela);
            }

        }


    }
}
