using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_5__Sroters_
{
    public class BubbleSorter
    {
        public static int[] array;
        static int arraySize;

        public BubbleSorter(int[] Array)
        {
            array = Array;
            arraySize = Array.Length;
        }

        public void BubbleSorting()
        {
            bool swapped;

            do
            {
                Console.WriteLine();
                PrintArray(array);
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i + 1] < array[i])
                    {
                        Swap(array, i, i + 1);
                        swapped = true;
                    }
                }
            }
            while (swapped);
            Console.WriteLine();
        }

        public static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
                if (i != array.Length - 1)
                    Console.Write(array[i] + "; ");
                else Console.Write(array[i]);
            Console.Write("]");
        }

        public static void Swap(int[] array, int index1, int index2)
        {
            int tempValue;

            tempValue = array[index1];
            array[index1] = array[index2];
            array[index2] = tempValue;
        }
    }
}
