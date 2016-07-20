
# Just for test 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_5__Sroters_
{
    class Program
    {
        public static int arraySize;
        public static int[] numericArray;

        static void Main(string[] args)
        {


		Console.Write("\nTest line_1!");
		Console.Write("\nTest line_2!");
		Console.Write("\nTest line_3!");
		
		
            bool answerYes = true;
            int chosenOption;
            string answer;

            Console.Write("Hello, dear User!\n");

            //The following block is execude every time when user wants to repeat program execution
            //
            while (answerYes)
            {
                Console.Write("\nWould you like to create and fill an array by yourself or you prefer to generate it randomly?\n1-Create the new array manually;\n2-Create the random array\nPlease, make your choice: ");

                while (!Int32.TryParse(Console.ReadLine(), out chosenOption) && (chosenOption != 1 || chosenOption != 2))
                {
                    Console.Write("You have entered a wrong value. Please, try again (use numeric values from suggested): ");
                }

                if (chosenOption == 1)
                {
                    Console.Write("\nPlease, set a size of an array you want and press Enter: ");

                    //Validation for a value(-s) user may enter; the size of array shouldn't be '0' and it shouldn't be filled by symbols - only numeric values
                    //
                    while (!Int32.TryParse(Console.ReadLine(), out arraySize) || arraySize == 0)
                    {
                        Console.Write("You have entered a wrong value (or '0'). Please, try again (use numeric values): ");
                    }

                    numericArray = new int[arraySize];

                    //The following lines give user the opportunity to fill the array by himself
                    //
                    Console.WriteLine("The size of array was set to {0}\n\nPlease, fill array by entering any numers you want.", arraySize);

                    arrayFilling();

                }
                else
                {
                    Console.Write("\nPlease, set a size of an array you want and press Enter: ");

                    //Validation for a value(-s) user may enter; the size of array shouldn't be '0' and it shouldn't be filled by symbols - only numeric values
                    //
                    while (!Int32.TryParse(Console.ReadLine(), out arraySize) || arraySize == 0)
                    {
                        Console.Write("You have entered a wrong value (or '0'). Please, try again (use numeric values): ");
                    }

                    numericArray = new int[arraySize];

                    Random rand = new Random();
                    for (int i = 0; i < numericArray.Length; i++)
                    {
                        numericArray[i] = rand.Next(100);
                    }
                }

                //User may print out the array he has filled
                //
                Console.Write("\nThank you! You have successfully filled the array. Do you want to print out the array? (Press Y/N): ");

                answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    Console.WriteLine();
                    printArrayElements(numericArray);
                }

                Console.Write("\n\nWhich sorting method whould you like to use for you array?\n1 - Bubble Sorting;\n2 - Insertion Sorting\nPlease, make your choose: ");

                while (!Int32.TryParse(Console.ReadLine(), out chosenOption) && (chosenOption != 1 || chosenOption != 2))
                {
                    Console.Write("You have entered a wrong value. Please, try again (use numeric values from suggested): ");
                }

                Console.WriteLine("\nSorting iterations are the following:");
                if (chosenOption == 1)
                {
                    BubbleSorter bS = new BubbleSorter(numericArray);
                    bS.BubbleSorting();
                }
                else
                {
                    InsertionSorter iS = new InsertionSorter(numericArray);
                    iS.InsertionSorting();
                }
                
                Console.Write("\nDo you want to sort another array? (Press Y/N): ");

                answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    answerYes = true;
                    Console.Clear();
                }
                else answerYes = false;
            }
        }

        public static void arrayFilling()
        {

            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("[{0}] -> ", i + 1);
                while (!Int32.TryParse(Console.ReadLine(), out numericArray[i]))
                {
                    Console.Write("You have entered a wrong value. Please, try again (use numeric values): ");
                }
            }
        }

        public static void printArrayElements(int[] array)
        {
            Console.WriteLine("The array consists of the following elements: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");

            for (int i = 0; i < arraySize; i++)
            {
                if (i == (arraySize - 1))
                {
                    animatedArrayOutput(array[i]);
                }
                else
                {
                    animatedArrayOutput(array[i]);
                    Console.Write("; ");
                }

            }
            Console.Write("]\n");
            Console.ResetColor();
        }


        public static void animatedArrayOutput(int number)
        {
            string curNumber = "" + number;
            int curRow, curCol, curLenght, numberLenght;
            string curString, tempChar;
            int tempValue;

            numberLenght = curNumber.Length;

            for (int i = 0; i < numberLenght; i++)
            {
                tempChar = curNumber[i].ToString();
                Int32.TryParse(tempChar, out tempValue);

                for (int j = 0; j < tempValue; j++)
                {
                    curRow = Console.CursorTop;
                    curCol = Console.CursorLeft;
                    curString = "" + j;
                    curLenght = curString.Length;
                    Console.Write(curString);
                    Thread.Sleep(100);
                    Console.SetCursorPosition(curCol, curRow);
                    curString.Remove(0, curLenght);
                }

                Console.Write(tempChar);

            }
        }
    }
}
