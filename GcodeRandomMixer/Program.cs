
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using Topshelf.Runtime.Windows;

namespace GcodeRandomMixer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                // run as windows app
                Application.EnableVisualStyles();
                Application.Run(new Form1());
            }
            else
            {
                // run as console app
                NativeMethods.AllocConsole();
                Console.WriteLine("Hello World");
                //Console.ReadLine();
                string originalFile = args[0];
                string newfile = originalFile.Replace(".gc", "_mix.gc");
                int extruders = 0;
                string searchText = ";LAYER:";
                if (args.Length > 1)
                {
                    newfile = args[2];
                }
                if (args.Length > 2)
                {
                    extruders = int.Parse(args[3]);
                }
                if (args.Length > 3)
                {
                    searchText = args[4];
                }
                var mix = new gcodeRandomize(); 
                mix.GenerateMix(originalFile, newfile, extruders, searchText);

                NativeMethods.FreeConsole();
            }
            //Application.Run(new Form1());
        }

    }
    internal static class NativeMethods
    {
        // http://msdn.microsoft.com/en-us/library/ms681944(VS.85).aspx
        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
        /// <remarks>
        /// A process can be associated with only one console,
        /// so the function fails if the calling process already has a console.
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int AllocConsole();

        // http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx
        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
        /// <remarks>
        /// If the calling process is not already attached to a console,
        /// the error code returned is ERROR_INVALID_PARAMETER (87).
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();
    }
}
