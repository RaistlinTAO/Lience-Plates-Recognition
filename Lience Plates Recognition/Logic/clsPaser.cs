#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2013 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: Lience Plates Recognition
// PROJECT:    Lience Plates Recognition
// FILENAME:  clsPaser.cs
// 
// CREATED IN 11:43 PM (23/05/2013)
// 
// LAST EDITED: 12:56 AM (25/05/2013)

#endregion

using System;
using System.Text;

namespace Lience_Plates_Recognition.Logic
{
    internal static class clsPaser
    {
        internal static bool CheckNumber(string iNumber, bool MultiLine)
        {
            try
            {
                bool reachNumber = false;
                int FirstNumber = 0;
                int TotalNumberNum = 0;
                int TotalDigitalNum = 0;
                int iWeight = 0;
                int i = 0;

                if (MultiLine)
                {
                    iNumber = iNumber.Replace("\r\n", "");
                }

                //上面是移除多行车牌的换行
                foreach (char iTemp in iNumber)
                {
                    if (!reachNumber)
                    {
                        if (char.IsNumber(iTemp))
                        {
                            FirstNumber = i;
                            //找到车牌中第一个数字在哪里
                            reachNumber = true;
                        }
                    }

                    i++;
                }

                //车牌中数字的个数
                TotalNumberNum = iNumber.Length - FirstNumber - 1;
                //车牌中前面的字符串总量
                TotalDigitalNum = iNumber.Length - TotalNumberNum - 1;
                //最后一位为hash位置

                //计算英文字符的hash值
                switch (TotalDigitalNum)
                {
                    case 0:
                        return false;
                    case 1:
                        iWeight += HashStr(iNumber.Substring(0, 1))*4;
                        break;
                    case 2:
                        iWeight += HashStr(iNumber.Substring(0, 1))*9 + HashStr(iNumber.Substring(1, 1))*4;
                        break;
                    case 3:
                        iWeight += HashStr(iNumber.Substring(1, 1))*9 + HashStr(iNumber.Substring(2, 1))*4;
                        break;
                }

                //计算数字的hash值
                switch (TotalNumberNum)
                {
                    case 0:
                        return false;
                    case 1:
                        iWeight += int.Parse(iNumber.Substring(FirstNumber, 1))*2;
                        break;
                    case 2:
                        iWeight += int.Parse(iNumber.Substring(FirstNumber, 1))*3;
                        iWeight += int.Parse(iNumber.Substring(FirstNumber + 1, 1))*2;
                        break;
                    case 3:
                        iWeight += int.Parse(iNumber.Substring(FirstNumber, 1))*4;
                        iWeight += int.Parse(iNumber.Substring(FirstNumber + 1, 1))*3;
                        iWeight += int.Parse(iNumber.Substring(FirstNumber + 2, 1))*2;
                        break;
                    case 4:
                        iWeight += int.Parse(iNumber.Substring(FirstNumber, 1))*5;
                        iWeight += int.Parse(iNumber.Substring(FirstNumber + 1, 1))*4;
                        iWeight += int.Parse(iNumber.Substring(FirstNumber + 2, 1))*3;
                        iWeight += int.Parse(iNumber.Substring(FirstNumber + 3, 1))*2;
                        break;
                }
                iWeight = iWeight%19;

                return CheckValid(iWeight, iNumber.Substring(iNumber.Length - 1, 1));
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static bool CheckValid(int CheckSum, string LastDigital)
        {
            string CompareValue = "";
            switch (CheckSum)
            {
                case 0:
                    CompareValue = "A";
                    break;
                case 1:
                    CompareValue = "Z";
                    break;
                case 2:
                    CompareValue = "Y";
                    break;
                case 3:
                    CompareValue = "X";
                    break;
                case 4:
                    CompareValue = "U";
                    break;
                case 5:
                    CompareValue = "T";
                    break;
                case 6:
                    CompareValue = "S";
                    break;
                case 7:
                    CompareValue = "R";
                    break;
                case 8:
                    CompareValue = "P";
                    break;
                case 9:
                    CompareValue = "M";
                    break;
                case 10:
                    CompareValue = "L";
                    break;
                case 11:
                    CompareValue = "K";
                    break;
                case 12:
                    CompareValue = "J";
                    break;
                case 13:
                    CompareValue = "H";
                    break;
                case 14:
                    CompareValue = "G";
                    break;
                case 15:
                    CompareValue = "E";
                    break;
                case 16:
                    CompareValue = "D";
                    break;
                case 17:
                    CompareValue = "C";
                    break;
                case 18:
                    CompareValue = "B";
                    break;
            }
            return CompareValue == LastDigital;
        }

        internal static int HashStr(string Char)
        {
            //int iResult = 0;
            /*
            switch (Char)
            {
                case "A":
                    iResult = 1;
                    break;
                case "B":
                    iResult = 2;
                    break;
                case "C":

                    iResult = 3;
                    break;
                case "D":

                    iResult = 4;
                    break;
                case "E":
                    iResult = 5;
                    break;
                case "F":
                    iResult = 6;
                    break;
                case "G":
                    iResult = 7;
                    break;
                case "H":
                    iResult = 8;
                    break;
                case "I":
                    iResult = 9;
                    break;
                case "J":
                    iResult = 10;
                    break;
                case "K":
                    iResult = 11;
                    break;
                case "L":
                    iResult = 12;
                    break;
                case "M":
                    iResult = 13;
                    break;
                case "N":
                    iResult = 14;
                    break;
                case "O":
                    iResult = 15;
                    break;
                case "P":
                    iResult = 16;
                    break;
                case "Q":
                    iResult = 17;
                    break;
                case "R":
                    iResult = 18;
                    break;
                case "S":
                    iResult = 19;
                    break;
                case "T":
                    iResult = 20;
                    break;
                case "U":
                    iResult = 21;
                    break;
                case "V":
                    iResult = 22;
                    break;
                case "W":
                    iResult = 23;
                    break;
                case "X":
                    iResult = 24;
                    break;
                case "Y":
                    iResult = 25;
                    break;
                case "Z":
                    iResult = 26;
                    break;
            }
            */
            byte[] bb = Encoding.ASCII.GetBytes(Char);
            int iResult = (bb[0]) - 64;
            return iResult;
        }
    }
}