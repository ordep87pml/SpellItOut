using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellItOut
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Write a number between 0 and 1 billion:");
                Console.WriteLine(Environment.NewLine);
                string input = Console.ReadLine();

                int value;
                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Number is not a valid number");
                }
                else
                {
                    NumberToWords conversor = new SpellItOut.NumberToWords();
                    Console.WriteLine(conversor.Converter(value));
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
