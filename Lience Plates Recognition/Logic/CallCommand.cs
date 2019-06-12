#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2013 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: Lience Plates Recognition
// PROJECT:    Lience Plates Recognition
// FILENAME:  CallCommand.cs
// 
// CREATED IN 11:34 PM (23/05/2013)
// 
// LAST EDITED: 12:56 AM (25/05/2013)

#endregion

using System.Diagnostics;

namespace Lience_Plates_Recognition.Logic
{
    internal static class CallCommand
    {
        internal static void CallCammand(string cmdPath, string P)
        {
            var myprocess = new Process();
            try
            {
                var startInfo = new ProcessStartInfo(cmdPath, P) {WindowStyle = ProcessWindowStyle.Hidden};
                //startInfo.WorkingDirectory = workdirectory;
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.CreateNoWindow = true;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                myprocess.WaitForExit();
            }
            finally
            {
                myprocess.Close();
                myprocess.Dispose();
            }
        }
    }
}