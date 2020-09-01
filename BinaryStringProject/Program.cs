using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStringProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGood = true;
            string inputStr;

            Console.WriteLine("Type Input");
            inputStr = Console.ReadLine();
           
            if (!IsBinaryString(inputStr)) // check given input is Binary or not
            {
                Console.WriteLine("Invalid Binary string");
                Console.Read();
                return;
            }

            if (checkFirstCondition(countOnes(inputStr), countZeros(inputStr))) // check 1st condition
            {
                for (int i = 1; i < inputStr.Length; i++)
                {
                    var res = inputStr.Substring(0, i);
                    if (!checkSecondCondition(countOnes(res), countZeros(res)))  // check 2nd condition
                    {
                        Console.WriteLine("Bad Binary String");
                        Console.WriteLine("The number of 1's is less than the number of 0's in one of prefixes of given Binary string");
                        isGood = false;
                        break;
                    }
                }

                if (isGood)
                    Console.WriteLine("Good Binary String");
            }
            else
            {
                Console.WriteLine("Bad Binary String");
                Console.WriteLine("The number of 0's is not equal to the number of 1's");
            }
            Console.ReadKey();
        }

      static  int  countOnes(string input)
        {
            return input.Length - input.Replace("1", "").Length;
        }
      static  int countZeros(string input)
        {
            return input.Length - input.Replace("0", "").Length;
        }
        static bool checkFirstCondition(int OnesLength, int ZerosLength)
        {
            if (OnesLength == ZerosLength)
                    return true;
            
                return false;
        }

        static bool checkSecondCondition(int OnesLength, int ZerosLength)
        {
            if (OnesLength >= ZerosLength)
                return true;

            return false;
        }
        static bool IsBinaryString(string str)
        {
            foreach (char c in str)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }
    }
}
