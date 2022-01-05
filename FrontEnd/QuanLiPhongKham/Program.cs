using Inventec.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongKham
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
            log4net.Config.DOMConfigurator.Configure();
            LogSystem.Info("OnApplicationStart. Time=" + DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss"));
            Application.Run(new FrmDangNhap());
        }
    }
}
