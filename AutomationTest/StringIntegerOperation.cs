using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAndIntergerOperation
{
    public static class StringIntegerOperation
    {

        static void Main(string[] args)
        {
            Console.WriteLine("----String---");
            Console.WriteLine("Please Enter the string to remove repeated characters-------");
            string inputStr = Console.ReadLine();
            string newStr = StringIntegerOperation.RemoveRepetitiveCharacters(ref inputStr);
            Console.WriteLine("New String is " + newStr);


            Console.WriteLine("Please Enter the string to count number of words-------\n");
            inputStr = Console.ReadLine();
            int numOfWrds = StringIntegerOperation.CountNumberOfWords(ref inputStr);
            Console.WriteLine("Number of words are " + numOfWrds);


            int num;
            Console.WriteLine("Please enter integer number to check palindrome----\n");
            if (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("It is not integer");
            }
            int sum = CheckNumberPalindrome(num);
            Console.WriteLine("\n The Reversed Number is: {0} \n", sum);

            if (num == sum)
            {
                Console.WriteLine("\n Number is Palindrome \n");
            }
            else
            {
                Console.WriteLine("\n Number is not a palindrome \n");
            }

            Console.WriteLine("Sort the array in ascending order------\n");
            int[] arr = { 23, 34, 1, 2, 4 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            StringIntegerOperation.SortArrayInAschendindOrder(ref arr);
            Console.WriteLine("\n");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.ReadLine();
        }
        public static string RemoveRepetitiveCharacters(ref string str)
        {
            int len = str.Length;
            char[] strArray = new char[len];
            int arrayIndex = 0;
            int i = 0;
            int j = 0;

            strArray[arrayIndex] = str[0];
            for (i = 1; i < str.Length; i++)
            {
                for (j = 0; j < i; j++)
                {
                    if (str[i].Equals(str[j]) || (str[i] >= 'a' && str[i] - 'a' + 'A' == str[j]) || (str[i] <= 'Z' && str[i] + 'a' - 'A' == str[j]))
                    {
                        break;
                    }
                }
                if (i == j)
                {
                    arrayIndex = arrayIndex + 1;
                    strArray[arrayIndex] = str[i];
                }

            }
            return new string(strArray);
        }

        public static int CountNumberOfWords(ref string str)
        {

            int i = 0;
            int numOfWrds = 0;
            if (str.Length > 0) { numOfWrds = 1; }
            for (i = 0; i < str.Length; i++)
            {

                if (str[i].ToString() == " ")
                {
                    numOfWrds = numOfWrds + 1;
                }
            }
            return numOfWrds;
        }
        public static int CheckNumberPalindrome(int num)
        {
            int rem, sum = 0, temp;

            temp = num;
            while (num > 0)
            {
                rem = num % 10;
                num = num / 10;
                sum = sum * 10 + rem;
            }
            return sum;
        }

        public static void SortArrayInAschendindOrder(ref int[] arr)
        {
            for (int pass = 1; pass < arr.Length - 1; pass++)
            {
                // Count how many times this next loop
                // becomes shorter and shorter
                for (int i = 0; i < arr.Length - pass; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // Exchange elements
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }
        }
    }
}
