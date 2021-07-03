using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndAnagrams
{
    class AnotherSolution2
    {

        public static void Main(string[] args)
        {

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = SherlockAndAnagrams(s);

                Console.WriteLine(result);
            }


        }

        private static int SherlockAndAnagrams(string s)
        {
            int count = 0;
            Dictionary<string, int> subItems = new Dictionary<string, int>();

            subItems = prepareDictionart(s);

            count = calculatePairs(subItems);

            return count;
        }

        private static Dictionary<string, int> prepareDictionart(string s)
        {
            Dictionary<string, int> subItems = new Dictionary<string, int>();


            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (j + i + 1 <= s.Length)
                    {
                        var subPart = s.Substring(j, i + 1);

                        string sub = new string(subPart.ToCharArray().OrderBy(o => o).ToArray());

                        if (subItems.ContainsKey(sub))
                        {
                            subItems[sub]++;
                        }
                        else
                        {
                            subItems.Add(sub, 1);
                        }
                    }
                }

            }

            return subItems;
        }

        private static int calculatePairs(Dictionary<string, int> subItems)
        {
            int count = 0;
            foreach (var item in subItems.Keys)
            {
                int itemVal = subItems[item];
                count += itemVal * (itemVal - 1) / 2;
            }
            return count;
        }
    }
}
