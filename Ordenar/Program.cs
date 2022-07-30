using System;
using System.Windows.Forms;

namespace Ordenar
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class VetorEventArgs // EventArgs
    {
        public int indice;
        public int valor;

        public override string  ToString()
        {
            return indice.ToString() + " - " + valor.ToString();
        }
    }
}
