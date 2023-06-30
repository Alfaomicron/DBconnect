using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_connection
{
    public class connectionInstance
    {
        public static dbconnection connection;
        public static bool connected = false;
    }

    public class configParams
    {
        public static String dbURL="hddnas.ddns.net";
        public static String dbPort="1300";
        public static String dbUname="sa";
        public static String dbPasswd="Myrmarache31415!";
        public static bool ready = true;
    }

    public class graphdata
    {
        public static Int64 nsamples = 5;
        public static Int64 tsampling = 5000;
    }

    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
