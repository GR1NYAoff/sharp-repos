using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueJsTask
{
    public class MaxBottlesApplication
    {
        public int Run(string args)
        {
            var intArgs = args.Split(' ').Select(x => int.Parse(x)).ToArray();

            Func<int, int, int> GetBottles = (x, y) =>
            {
                var temp = (x / y) + x % y;
                if ((temp + 1) % y == 0 && temp >= y)
                    return x + temp;
                if (temp >= y)
                    return x + (x / y) + (temp / y);
                return x + (x / y);
            };

            return GetBottles(intArgs[0], intArgs[1]);
        }
    }
}
