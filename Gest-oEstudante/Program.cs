using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gest_oEstudante
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new login_Form());
            login_Form telaDeLogin = new login_Form();

            if (telaDeLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormPrincipal());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
