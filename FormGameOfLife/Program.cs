using System;
using System.Windows.Forms;

namespace FormGameOfLife
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            using (var form = new Form1()) {
                form.Show();
                form.NewGame();
                form.GameLoop();
            }
        }
    }
}
