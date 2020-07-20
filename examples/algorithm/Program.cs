using algorithm.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //IAlgorithmTask task = new BubbleSortTask();
            //task.RunTask();

            //Console.WriteLine(CompressString("aabcccccaaa"));

            //var nums = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789, 54 };
            //var result = TwoSum(nums, 9);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(IsHappy(131));
            Console.ReadLine();
        }

        static bool IsHappy(int n)
        {
            if (n == 4) return false;
            string nStr = n.ToString();
            int sum = 0;
            foreach (var c in nStr)
            {
                sum += Convert.ToInt32(c.ToString()) * Convert.ToInt32(c.ToString());
            }
            if (sum != 1)
            {
                return IsHappy(sum);
            }
            else
            {
                return true;
            }
        }

        static int[][] FlipAndInvertImage(int[][] A)
        {
            var result = new int[A.Length][];
            int upLimit = A.Length % 2 == 0 ? A.Length / 2 - 1 : A.Length / 2;

            for (int i = 0; i < A.Length; i++)
            {
                var row = new int[A[i].Length];
                for (int j = 0; j <= upLimit; j++)
                {
                    row[j] = A[i][A[i].Length - 1 - j] == 0 ? 1 : 0;
                    row[A[i].Length - 1 - j] = A[i][j] == 0 ? 1 : 0;
                }
                result[i] = row;
            }
            return result;
        }

        static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    result[0] = map[target - nums[i]];
                    result[1] = i;
                    return result;
                }
                else
                {
                    if (map.ContainsKey(nums[i]))
                    {
                        continue;
                    }
                    map.Add(nums[i], i);
                }
            }

            return result;
        }

        static string CompressString(string S)
        {
            char header = S[0];
            int len = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == header)
                {
                    len++;
                }
                else
                {
                    sb.AppendFormat("{0}{1}", header, len);
                    header = S[i];
                    len = 1;
                }
            }
            sb.AppendFormat("{0}{1}", header, len);

            int resultLen = sb.ToString().Length;
            if (S.Length <= resultLen)
            {
                return S;
            }

            return sb.ToString();
        }
    }
}
