using System;
using System.Linq;

    public class SequenceOfDifferentPairs
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
            var counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (counter >= pairs.Length)
                {
                    output[i] = 0;
                    continue;
                }

                if (numbers[i] == pairs[counter])
                    output[i] = pairs[counter + 1];
                else
                    output[i] = 0;

                counter += 2;
            }

            output[numbers.Length] = Separator;

            return output;
        }
    }
