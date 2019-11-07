using System;

namespace Algorithms
{
    class MainClass
    {
        static void bubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < (n - i - 1); j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        //swap values
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.Write("Unsorted Array: ");
            printArray(arr);
            Console.WriteLine();

            bubbleSort(arr);

            Console.Write("Sorted Array: ");
            printArray(arr);
        }
    }
}
