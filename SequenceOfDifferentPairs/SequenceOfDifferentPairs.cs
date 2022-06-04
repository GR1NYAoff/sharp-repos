using System;
using System.Linq;

namespace SequenceOfDifferentPairs
{
    internal class SequenceOfDifferentPairs
    {
        private const int Separator = -1;
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var pairs = inputNumbers.TakeWhile(p => p != Separator).ToArray();
            var numbers = inputNumbers.Reverse().Skip(1).TakeWhile(n => n != Separator).Reverse().ToArray();

            Console.Write(string.Join(" ", GetCorrectSequence(pairs, numbers)));
        }

        private static int[] GetCorrectSequence(int[] pairs, int[] numbers)
        {
            var output = new int[numbers.Length + 1];
            var temp = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (temp >= pairs.Length)
                {
                    output[i] = 0;
                    continue;
                }

                if (numbers[i] == pairs[temp])
                    output[i] = pairs[temp + 1];
                else
                    output[i] = 0;

                temp += 2;
            }

            output[numbers.Length] = Separator;

            return output;
        }
    }
}
