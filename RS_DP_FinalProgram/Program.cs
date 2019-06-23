using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_DP_FinalProgram
{
    static class Program
    {
        public static Form1 thisForm1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            thisForm1 = new Form1();
            Application.Run(new Form1());
        }
    }
}
