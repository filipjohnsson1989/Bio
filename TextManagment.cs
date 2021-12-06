using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bio
{
    static class TextManagment
    {

        //Exempel på output: 1. Input, 2. Input, 3. Input osv.
        //Den får en text och upprepade den tio gånger med önskat format.
        public static string RepeatTextTenTimes(string text)
        {
            string result = string.Empty;

            //Bara för mer träning
            //var i = 1;
            //result = string.Concat(Enumerable.Repeat(text, 10).Select(t => $"{i}. {t}{(i++ < 10 ? ", " : ".")}"));

            for (int i = 1; i <= 10; i++)
                result += $"{i}. {text}{(i < 10 ? ", " : ".\r\n")}";

            return result;
        }

        //Den hittar det tredje ordet i en mening
        public static string FindTheThirdWord(string sentence)
        {
            var subSentence = Regex.Replace(sentence.Trim(), @"\s+", " ").Split(' ');

            if (subSentence.Length >= 3) return subSentence[2];

            return string.Empty;
        }
    }
}
