#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2013 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: Lience Plates Recognition
// PROJECT:    Lience Plates Recognition
// FILENAME:  clsImagemagick.cs
// 
// CREATED IN 11:35 PM (23/05/2013)
// 
// LAST EDITED: 12:56 AM (25/05/2013)

#endregion

using System.Drawing;

namespace Lience_Plates_Recognition.Logic
{
    internal static class clsImagemagick
    {
        internal static void CutImage(string MagicPATH, string IMGPath)
        {
            Image pic = Image.FromFile(IMGPath);
            int intWidth = pic.Width;
            int intHeight = pic.Height/2;

            CallCommand.CallCammand(MagicPATH + "\\convert.exe",
                                    " \"" + IMGPath + "\" " + " -crop " + intWidth + "x" + intHeight + "+" + " dest.bmp");
        }

        internal static void ConvertImg(string MagicPATH, string IMGPath, string Fname)
        {
            CallCommand.CallCammand(MagicPATH + "\\convert.exe",
                                    " \"" + IMGPath + "\" " + Fname + ".tiff");
        }

        internal static string MagicIMG(string MagicPATH, string IMGPath, string ResultName, bool Multi)
        {
            int intWidth;
            int intHeight;
            Image pic = Image.FromFile(IMGPath);
            int x = pic.Width;
            int y = pic.Height;
            if (!Multi)
            {
                intWidth = pic.Width - pic.Width/30; //长度像素值
                intHeight = pic.Height - pic.Width/30; //高度像素值}
                CallCommand.CallCammand(MagicPATH + "\\convert.exe",
                                        " -level 100%,0% -despeckle -crop " + intWidth + "x" + intHeight + "+" +
                                        pic.Width/60 + "+" + pic.Width/60 +
                                        " -resize " + x*3 + "x" + y*3 + " \"" + IMGPath + "\" " + ResultName + ".tiff");
            }
            else
            {
                intWidth = pic.Width; //长度像素值
                intHeight = pic.Height; //高度像素值}
                CallCommand.CallCammand(MagicPATH + "\\convert.exe",
                                        " -level 100%,0% -despeckle" +
                                        " -resize " + x*3 + "x" + y*3 + " \"" + IMGPath + "\" " + ResultName + ".tiff");
            }


            return ResultName + ".tiff";
        }
    }
}