using System;
using System.Linq;
using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var len = Array.IndexOf(input, -1);
        
            for (var i = 0; i < len; i += 2)
            {
                pairs.Add(input[i], input[i + 1]);
            }
        
            for (var i = len + 1; i < input.Length - 1; i++)
            {
                if (pairs.ContainsKey(input[i]))
                {
                    Console.Write(pairs[input[i]]);
                }
                else
                {
                    Console.Write(0);
                }

                Console.Write(' ');
            }

            Console.Write(-1);

        }
    }
