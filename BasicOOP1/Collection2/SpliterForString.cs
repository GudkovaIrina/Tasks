using System;
using System.Collections.Generic;

namespace Collection2
{
    internal class SpliterForString
    {
        static public Dictionary<string, int> Spliter(string str)
        {
            string[] arr = str.Split(new char[] { ' ', '.'}, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, int>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i].ToLower()))
                {
                    int k = 1;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i].Equals(arr[j], StringComparison.InvariantCultureIgnoreCase))
                        {
                            k++;
                        }
                    }
                    dict.Add(arr[i].ToLower(), k);
                }
            }
            return dict;
        }

        static public double AverageLengthOfWords(string str)
        {
            string[] arr = str.Split(new char[] { ' ', '.', ',', ';', ':', '\'', '\"', '(', ')', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            double averageLength = 0;
            foreach (var item in arr)
            {
                averageLength += item.Length;
            }
            return averageLength/arr.Length;
        }
    }
}