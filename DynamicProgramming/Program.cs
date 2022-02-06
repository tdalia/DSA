using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DPBasic dp = new DPBasic();
            //dp.Execute_01KnapsackProblem();

            //dp.ExecuteMaxProfit();

            //dp.ExecuteLongestSubArray();

            dp.ExecuteFibonacci();

            //dp.ExeNumberOfPaths();

            //dp.ExeClimbStairs();

            //dp.ExeFlipArray();

            dp = null;
        }
    }
}
