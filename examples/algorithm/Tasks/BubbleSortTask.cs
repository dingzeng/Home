using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm.Tasks
{
    public class BubbleSortTask : IAlgorithmTask
    {
        public void RunTask()
        {
            var arr = RandomArray();
            PrintArray(arr);
            Console.WriteLine("-----------------");

            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            PrintArray(arr);
        }

        private int[] RandomArray()
        {
            var length = new Random().Next(10, 100);
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new Random(i).Next(0, 200);
            }
            return result;
        }

        private void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
