using System;
using System.Collections.Generic;

namespace SampleConApp
{
    internal static class StringEncoder
    {
        private const string key = "the quick and brown fox jumps over the lazy dog";
        private static Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

        private static void Main(string[] args)
        {
            string text = UIConsole.GetString("Enter your string you wish to Encode");

            Console.WriteLine(Encoder(text.ToLower()));
        }

        private static string Encoder(string text)
        {
            DictionaryMaker();
            if (text.Length == 0)
            {
                throw new ArgumentException("Inavlid argument length");
            }
            if (text == null)
            {
                throw new NullReferenceException("text cannot be null");
            }
            string res = "";
            int i = 0;
            foreach (var item in text)
            {
                if (item == ' ')
                {
                    res += "-";
                    continue;
                }
                if (keyValuePairs[item] < 10)
                {
                    res += $"0{keyValuePairs[item]}";
                }
                else
                {
                    res += $"{keyValuePairs[item]}";
                }

                if (i != text.Length - 1)
                {
                    var nextItem = text[i + 1];
                    if (!nextItem.Equals(' '))
                    {
                        res += ",";
                    }
                }
                i++;
            }
            return res.TrimEnd(',');
        }

        private static void DictionaryMaker()
        {
            int word = 0;
            int place = 0;
            foreach (var c in key)
            {
                if (c.Equals(' '))
                {
                    word++;
                    place = 0;
                    continue;
                }
                if (keyValuePairs.ContainsKey(c)) { place++; }
                else
                {


                    keyValuePairs[c] = word * 10 + place;
                    place++;
                }
            }
        }
    }
}
