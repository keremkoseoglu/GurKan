using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{

    public class Common
    {
        public enum STATUS { GREEN, YELLOW, RED, GRAY, WORKING };

        public static string pack(string Text)
        {
            if (Text == null || Text.Length <= 0) return Text;

            string ret = Text;
            while (ret.Substring(0, 1) == "0") ret = ret.Substring(1, ret.Length - 1);
            return ret;
        }

        public static string parseDecimal(decimal D)
        {
            decimal p1 = System.Math.Truncate(D);
            if (p1 != D) return D.ToString();
            else
            {
                string k = D.ToString();

                if (k.Length < 4) return k;
                else if (k.Substring(k.Length - 4, 4) == ",000" || k.Substring(k.Length - 4, 4) == ".000")
                {
                    return k.TrimEnd('0').TrimEnd(',').TrimEnd('.');
                }
                else
                {
                    return k;
                }
            }
        }

        #region SPELL_AMOUNT

        public static string getDecimalText(decimal D)
        {
            string wtext = Common.parseDecimal(D);
            string ret = "";

            if (wtext.Length <= 4)
            {
                for (int n = 0; n < wtext.Length; n++) ret += getDigitText(wtext.Substring(n, 1), wtext.Length - n);
            }
            else if (wtext.Length == 5)
            {
                ret =
                    getDigitText(wtext.Substring(0, 1), 2) +
                    getDigitText(wtext.Substring(1, 1), 1) +
                    "BÝN";

                for (int n = 2; n < wtext.Length; n++) ret += getDigitText(wtext.Substring(n, 1), wtext.Length - n);
            }
            else if (wtext.Length == 6)
            {
                ret =
                    getDigitText(wtext.Substring(0, 1), 3) +
                    getDigitText(wtext.Substring(1, 1), 2) +
                    getDigitText(wtext.Substring(2, 1), 1) +
                    "BÝN";

                for (int n = 3; n < wtext.Length; n++) ret += getDigitText(wtext.Substring(n, 1), wtext.Length - n);
            }
            
            return ret;
        }

        private static string getDigitText(string Digit, int Order)
        {
            if (Order == 1)
            {
                switch (Digit)
                {
                    case "1": return "BÝR";
                    case "2": return "ÝKÝ";
                    case "3": return "ÜÇ";
                    case "4": return "DÖRT";
                    case "5": return "BEÞ";
                    case "6": return "ALTI";
                    case "7": return "YEDÝ";
                    case "8": return "SEKÝZ";
                    case "9": return "DOKUZ";
                }
            }
            else if (Order == 2)
            {
                switch (Digit)
                {
                    case "1": return "ON";
                    case "2": return "YÝRMÝ";
                    case "3": return "OTUZ";
                    case "4": return "KIRK";
                    case "5": return "ELLÝ";
                    case "6": return "ALTMIÞ";
                    case "7": return "YETMÝÞ";
                    case "8": return "SEKSEN";
                    case "9": return "DOKSAN";
                }
            }
            else if (Order == 3)
            {
                if (Digit == "1") return "YÜZ";
                else
                {
                    string x = getDigitText(Digit, 1);
                    if (x == "") return "";
                    return x + "YÜZ";
                }
            }
            else if (Order == 4)
            {
                if (Digit == "1") return "BÝN";
                else
                {
                    string x = getDigitText(Digit, 1);
                    if (x == "") return "";
                    return x + "BÝN";
                }
            }
            else if (Order == 5)
            {
                string x = getDigitText(Digit, 2);
                if (x == "") return "";
                return x + "BÝN";
            }
            else if (Order == 6)
            {
                string x = getDigitText(Digit, 3);
                if (x == "") return "";
                return x + "BÝN";
            }

            return "";
        }

        #endregion

    }
}
