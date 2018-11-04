using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> arr = new List<int>() { 100, 0 };             //{ 3, 2, 1 } { 1, -1, 0, 2, 3, 5 } { 1, 2, 3, 4, -1, -1, -1 };            
            var res = solution(arr.ToArray(), 2);
            Console.WriteLine(res);
        }

        public static int solution(int[] A, int D)
        {
            for (int k = 0; k < A.Length; k++)
            {
                if (A[k] == -1)
                {
                    continue;
                }

                if (D < k)
                {
                    return -1;
                }

                if (D + k > A.Length)
                {
                    return A[k];
                }
                int[] shortenedArr = new int[A.Length - k - 1];
                Array.Copy(A, k + 1, shortenedArr, 0, A.Length - k - 1);
                var res = solution(shortenedArr, D);
                if (A[k] > res && res != -1)
                {
                    return A[k];
                }
                else
                {
                    return res;
                }

            }

            return -1;
        }

        public static int Foo2(int[] arr, int numOfJumps)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] == -1)
                {
                    continue;
                }

                if (numOfJumps < k)
                {
                    return -1;
                }

                if (numOfJumps + k > arr.Length)
                {
                    return arr[k];
                }
                var res = Foo2(arr.Skip(k + 1).ToArray(), numOfJumps);
                if (arr[k] > res && res != -1)
                {
                    return arr[k];
                }
                else
                {
                    return res;
                }

            }

            return -1;
        }

        public static int Foo(int[] arr, int numOfJumps)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                if (numOfJumps > arr.Length)
                {
                    return -1;
                }
                if (k > numOfJumps)
                {
                    return -1;
                }

                if (numOfJumps + k >= arr.Length)
                {
                    return k;
                }
                else
                {
                    int[] shortArr = new int[arr.Length - k - 1];
                    Array.Copy(arr, k + 1, shortArr, 0, arr.Length - k - 1);
                    return Foo(shortArr, numOfJumps);
                }
            }

            return -1;
        }
    }
}
