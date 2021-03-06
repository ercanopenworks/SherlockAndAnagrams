using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndAnagrams
{
    class Program
    {

        static int SherlockAndAnagrams(string s)
        {
            // Sorted subs with their respective occurrence frequency
            var subFreqs = new Dictionary<string, int>();
            var count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i; j < s.Length; j++)
                {
                    //var subPart = s.Substring(i, j - i + 1);
                    //var subPartCharArray = subPart.ToCharArray();
                    //var subPartOrderedCharArray = subPartCharArray.OrderBy(p => p);
                    //var subPartToArray = subPartOrderedCharArray.ToArray();

                    //var sub = new string(subPartToArray);

                    var subPart = s.Substring(i, j - i + 1).ToCharArray().OrderBy(o => o).ToArray();
                    var sub = new string(subPart);

                    if (!subFreqs.ContainsKey(sub))
                    {
                        subFreqs.Add(sub, 1);
                    }
                    else
                    {
                        count += subFreqs[sub];
                        subFreqs[sub]++;
                    }
                }
            }

            return count;
        }

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


    }
}
