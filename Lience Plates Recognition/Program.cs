#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2013 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: Lience Plates Recognition
// PROJECT:    Lience Plates Recognition
// FILENAME:  Program.cs
// 
// CREATED IN 7:08 PM (21/05/2013)
// 
// LAST EDITED: 12:56 AM (25/05/2013)

#endregion

using System;
using System.Windows.Forms;
using Lience_Plates_Recognition.UI;

namespace Lience_Plates_Recognition
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}