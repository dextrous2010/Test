using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5__Sroters_
{
    public class InsertionSorter
    {
        public static int[] array;

        public InsertionSorter(int[] Array)
        {
            array = Array;
        }

        public void InsertionSorting()
        {
            bool swapped = false;

            Console.WriteLine();
            PrintArray(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] < array[i])
                {
                    Swap(array, i, i + 1);
                    swapped = true;

                    do
                    {
                        for (int j = i; j != 0; j--)
                        {
                            if (array[j] < array[j - 1] && swapped) Swap(array, j, j - 1);
                            else swapped = false;
                        }
                    } while (swapped);

                }
                Console.WriteLine();
                PrintArray(array);
            }
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
