using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShop.Common
{
    public class StringHelper
    {
        public static string ToUnSignString(string input)
        {
            ////Chuyen tu tieng viet co dau sang khong dau (cach 1)
            //string stFormD = input.Normalize(NormalizationForm.FormD);
            //StringBuilder sb = new StringBuilder();
            //for (int ich = 0; ich < stFormD.Length; ich++)
            //{
            //    System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            //    if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            //    {
            //        sb.Append(stFormD[ich]);
            //    }
            //}
            //sb = sb.Replace('Đ', 'D');
            //sb = sb.Replace('đ', 'd');
            //return (sb.ToString().Normalize(NormalizationForm.FormD));

            //Chuyen tu tieng viet co dau sang khong dau (cach 2)
            //Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            //string temp = s.Normalize(NormalizationForm.FormD);
            //return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            input = input.Trim();
            for(int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString()," ");
            }
            input = input.Replace(".", "-");
            input = input.Replace(",", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace(" ", "-");
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-");
            }
            return str2.ToLower();

        
        }
    }
}
