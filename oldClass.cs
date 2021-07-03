using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndAnagrams
{
    class oldClass
    {

        public class HashedAnagramString
        {
            public static int GetHashedAnagram(Dictionary<char, int> frequencyTable)
            {
                StringBuilder key = new StringBuilder();

                foreach (var item in frequencyTable.OrderBy(o => o.Key))
                {
                    key.Append(item.Key + item.Value.ToString());

                }

                return key.ToString().GetHashCode();
            }
        }
        static void Main(string[] args)
        {
            ProcessInput();
        }

        private static void ProcessInput()
        {
            var queries = int.Parse(Console.ReadLine());
            while (queries-- > 0)
            {
                var input = Console.ReadLine();
                var hashedAnagramDictionary = ConstructHashedAnagramDictionary(input);
                Console.WriteLine(CalculatePairs(hashedAnagramDictionary));
            }
        }

        private static int CalculatePairs(Dictionary<int, int> hashedAnagramDictionary)
        {
            int anagramaticPairs = 0;
            foreach (var item in hashedAnagramDictionary)
            {
                anagramaticPairs += item.Value * (item.Value - 1) / 2;

            }

            return anagramaticPairs;
        }

        private static Dictionary<int, int> ConstructHashedAnagramDictionary(string input)
        {
            var hashedAnagramDictionary = new Dictionary<int, int>();
            var length = input.Length;

            for (int substringLength = 1; substringLength < length; substringLength++)
            {
                for (int index = 0; index <= length - substringLength; index++)
                {
                    var frequenceTable = new Dictionary<char, int>();

                    for (int start = index; start < index + substringLength; start++)
                    {
                        char c = input[start];

                        if (frequenceTable.ContainsKey(c))
                        {
                            frequenceTable[c]++;
                        }
                        else
                        {
                            frequenceTable.Add(c, 1);
                        }
                    }

                    var key = HashedAnagramString.GetHashedAnagram(frequenceTable);

                    if (hashedAnagramDictionary.ContainsKey(key))
                    {
                        hashedAnagramDictionary[key]++;
                    }
                    else
                    {
                        hashedAnagramDictionary.Add(key, 1);
                    }
                }
            }

            return hashedAnagramDictionary;
        }
    }
}
