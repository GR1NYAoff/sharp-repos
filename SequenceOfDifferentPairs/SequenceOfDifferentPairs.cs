using System;
using System.Linq;
using System.Collections.Generic;

namespace SequenceOfDifferentPairs
{
    public class SequenceOfDifferentPairs
    {
        private const int Separator = -1;
        public static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()!.Split(' ').Select(x => int.Parse(x)).ToArray();
            var pairsOfNumbers = new Dictionary<int, int>();
            var numbers = new List<int>();
            var isDivided = false;


            for (var i = 0; i < inputNumbers.Length; i++)
            {
                if (inputNumbers[i] != Separator && !isDivided)
                {
                    pairsOfNumbers.Add(inputNumbers[i], inputNumbers[i + 1]);
                    i++;
                }
                else if (inputNumbers[i] != Separator && isDivided)
                {
                    numbers.Add(inputNumbers[i]);
                }
                else if (inputNumbers[i] == Separator && !isDivided)
                {
                    isDivided = true;
                }
                else
                {
                    break;
                }
            }

            Console.Write(string.Join(" ", GetCorrectSequence(numbers, pairsOfNumbers)));

        }

        private static int[] GetCorrectSequence(List<int> numbers, Dictionary<int, int> pairs)
        {
            var outputList = new List<int>();

            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == pairs.ElementAt(i).Key)
                    outputList.Add(pairs.ElementAt(i).Value);
                else
                    outputList.Add(0);
            }

            outputList.Add(Separator);

            return outputList.ToArray();
        }
    }
}
