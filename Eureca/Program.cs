using System;
using System.Windows.Forms;
using Npgsql;

namespace Eureca
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static int closed;
        [STAThread]
       
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Form2 auth = new Form2();
           Application.Run( new Form1());
        //    if (auth.closed==0)
            //
        }
    }
}
