#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2013 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: Lience Plates Recognition
// PROJECT:    Lience Plates Recognition
// FILENAME:  clsORC.cs
// 
// CREATED IN 11:34 PM (23/05/2013)
// 
// LAST EDITED: 12:56 AM (25/05/2013)

#endregion

using System.IO;

namespace Lience_Plates_Recognition.Logic
{
    internal static class clsORC
    {
        internal static string AnalyzePicture(string ORCPath, string IMGPath, string APPPath, bool isDouble)
        {
            if (!isDouble)
            {
                CallCommand.CallCammand(ORCPath + "\\tesseract.exe", " -l eng -psm 7 \"" + IMGPath + "\" out");
            }
            else
            {
                CallCommand.CallCammand(ORCPath + "\\tesseract.exe", " -l eng -psm 6 \"" + IMGPath + "\" out");
            }


            //他会在ORC目录下生成 out.txt 下面就读这个文件就好了

            while (true)
            {
                if (File.Exists(APPPath + "\\out.txt"))
                {
                    return File.ReadAllText(APPPath + "\\out.txt");
                }
            }
        }
    }
}