using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanDigitsConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to Roman Convertor\n Please enter an integer bewteen 0 and 3999");
            bool run=true;

            while (run)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'N' || key.KeyChar == 'n')
                    run = false;
                Console.WriteLine("\n");

                int val;
                int.TryParse(Console.ReadLine(), out val);

                if (val > 3999 || val < 1)
                {
                    Console.WriteLine("The numer you entered is out of range");
                    Console.WriteLine("Press Y to enter a number or q to n to quit");
                }
                else
                {
                    Console.WriteLine(DigitConvertor.IntToRoman(val));
                    Console.WriteLine("Do You Want To Convert Another number? Y/N");
                }


            }
        }
    }

    public class DigitConvertor
    {
        public static string IntToRoman(int num)
        {
            int multiplier;
            string finalstring = "";
            int val;
            char[] numarray = num.ToString().ToCharArray();

            for (int i = numarray.Length - 1; i >= 0; i--)
            {
                val = int.Parse(numarray[i].ToString());

                multiplier = (int)Math.Pow(10, numarray.Length - 1 - i);

                finalstring = GetRomanSign(multiplier, val) + finalstring;

            }

            return finalstring;
        }

        private static string GetRomanSign(int dec, int val)
        {
            if (val == 0)
                return "";
            string result = "";
            int rest, val1 = 0, val2;

            rest = val % 5;

            if (rest == 4)
            {
                val1 = dec * (val + 1);
                val2 = ((val - rest) == 5) ? val1 / 10 : val1 / 5;
                result += _romanConverter[val2] + _romanConverter[val1];
            }
            else
            {
                while (val > 0)
                {
                    if (val >= 5)
                    {
                        val1 = 5 * dec;
                        result += _romanConverter[val1];
                        val = val - 5;
                    }
                    else
                    {
                        result += _romanConverter[dec];
                        val--;
                    }



                }
            }

            return result;
        }

        private static Dictionary<int, string> _romanConverter = new Dictionary<int, string>()
        {
            { 1, "I" } ,
            { 5, "V" } ,
            { 10, "X" } ,
            { 50, "L" } ,
            { 100, "C" } ,
            { 500, "D" } ,
            { 1000, "M" }
        };

    }
}
