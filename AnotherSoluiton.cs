using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndAnagrams
{
    class AnotherSoluiton
    {
        public class HashedAnagramString
        {
            /*
             * Make sure that two anagram strings will have some hashed code
             * 
             * @frequencyTable - Dictionary<char, int>
             * The frequency table has to be sorted first and then construct 
             * a string with each char in alphabetic numbers concatenated by 
             * its occurrences. 
             * 
             */
            public static int GetHashedAnagram(Dictionary<char, int> frequencyTable)
            {
                // build frequency table dynamically, how many time? O(n*n), n 
                // is the string's length
                StringBuilder key = new StringBuilder();

                foreach (var item in frequencyTable.OrderBy(s => s.Key))
                {
                    key.Append(item.Key + item.Value.ToString());
                }

                return key.ToString().GetHashCode();
            }
        }

        static void Main(String[] args)
        {
            ProcessInput();
            //RunSampleTestcase(); 
        }
        public static void ProcessInput()
        {
            var queries = int.Parse(Console.ReadLine());

            while (queries-- > 0)
            {
                var input = Console.ReadLine();

                var hashedAnagramsDictionary = ConstructHashedAnagramsDictionary(input);

                Console.WriteLine(CalculatePairs(hashedAnagramsDictionary));
            }
        }
        public static Dictionary<int, int> ConstructHashedAnagramsDictionary(string input)
        {
            var hashedAnagramsDictionary = new Dictionary<int, int>();

            var length = input.Length;

            for (var substringLength = 1; substringLength < length; substringLength++)
            {
                for (var index = 0; index <= length - substringLength; index++)
                {
                    var frequencyTable = new Dictionary<char, int>();

                    // build frequency table dynamically, how many time? O(n*n), 
                    // n is the string's length
                    for (var start = index; start < index + substringLength; start++)
                    {
                        char c = input[start];
                        if (frequencyTable.ContainsKey(c))
                        {
                            frequencyTable[c]++;
                        }
                        else
                        {
                            frequencyTable.Add(c, 1);
                        }
                    }

                    var key = HashedAnagramString.GetHashedAnagram(frequencyTable);

                    if (hashedAnagramsDictionary.ContainsKey(key))
                    {
                        hashedAnagramsDictionary[key]++;
                    }
                    else
                    {
                        hashedAnagramsDictionary.Add(key, 1);
                    }
                }
            }

            return hashedAnagramsDictionary;
        }

        public static int CalculatePairs(Dictionary<int, int> hashedAnagrams)
        {
            // get pairs
            int anagrammaticPairs = 0;

            foreach (var count in hashedAnagrams)
            {
                anagrammaticPairs += count.Value * (count.Value - 1) / 2;
            }

            return anagrammaticPairs;
        }



    }
}
