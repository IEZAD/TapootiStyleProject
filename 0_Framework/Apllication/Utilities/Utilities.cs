using Azure.Core;
using System.Text.RegularExpressions;

namespace _0_Framework.Apllication.Utilities
{
    public static class Utilities
    {
        public static void RemovePlusFromCountryCode(this string countryCode)
        {
            if (countryCode.StartsWith("+"))
                countryCode.Replace("+", "");
        }

        public static string RemoveZeroAndPlusFromTheFrist(this string mobile)
        {
            while (mobile.StartsWith("0") || mobile.StartsWith("+"))
                mobile = mobile.Substring(1, mobile.Length - 1);
            return mobile;
        }

        public static T ToNumbers<T>(this string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) // empty Value
                    return default(T);

                input = input.Replace(",", "");
                input = input.Replace("/", ".");
                input = input.Replace('۰', '0');
                input = input.Replace('۱', '1');
                input = input.Replace('۲', '2');
                input = input.Replace('۳', '3');
                input = input.Replace('۴', '4');
                input = input.Replace('۵', '5');
                input = input.Replace('۶', '6');
                input = input.Replace('۷', '7');
                input = input.Replace('۸', '8');
                input = input.Replace('۹', '9');

                if (input.Count(f => f == '.') > 1) //more than 1 of float point
                    return default(T);


                string EnglishNumbers = "";

                foreach (var item in input)
                {
                    if (Char.IsDigit(item) || item == '.')
                        EnglishNumbers += item;
                }

                return (T)Convert.ChangeType(EnglishNumbers.Trim(), typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static string ReplaceArabicCharacters(this string inputString)
        {
            inputString = inputString.Replace("ي", "ی");
            inputString = inputString.Replace("ك", "ک");
            inputString = inputString.Replace("ﮎ", "ک");
            inputString = inputString.Replace("ﭘ", "پ");
            inputString = inputString.Replace("ي", "ی").Replace("ی", "ی");
            inputString = inputString.Replace("ك", "ک").Replace("ﮐ", "ک");
            var outputString = inputString.Trim();

            while (outputString.Contains("  "))
                outputString = outputString.Replace("  ", " ");

            return outputString.Trim();
        }

        public static int CompareTwoString(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        public static bool PersianCharacter(this string text)
        {
            return Regex.IsMatch(text, @"^[\u0600-\u06FF]+$");
        }
    }
}
