using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHotKeys
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            //No idea why but when used Guid from the assembly then createdNew always return false... although this didn't happen in other project
            //var assemblyGuidAttrib = (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0];
            //using (Mutex mutex = new Mutex(true, assemblyGuidAttrib.ToString(), out createdNew))
            using (Mutex mutex = new Mutex(true, "41a052de-7449-49ea-87e8-2143a3d33122", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    using (AppTray appIcon = new AppTray())
                    {
                        Application.Run();
                    }
                }
            }
        }
    }
}
