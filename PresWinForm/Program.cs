using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
namespace PresWinForm
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin login = new frmLogin();
            Application.Run(login);
            if (login.DialogResult == DialogResult.OK)
            {
                Application.Run(new frmPrincipal(login.local));
            }
        }
    }
}
