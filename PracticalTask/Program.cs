namespace PracticalTask
{
    internal static class Program
    {
        private static void Main()
        {
            var array = new int[] { 1, 2, 5, 5, 4, 7 };

            var resultArray = array.StatisticOfArray(new int[] { 1, 5, 3 });

            Console.WriteLine(string.Join(", ", resultArray));  // 1, 2, 0

            _ = Console.ReadKey();
        }
        public static int[] StatisticOfArray(this int[] array, int[] query)
        {
            var result = new int[query.Length];

            for (var i = 0; i < query.Length; i++)
            {
                result[i] = array.Where(x => x == query[i]).Count();
            }

            return result;
        }
    }

}
