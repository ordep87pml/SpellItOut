using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellItOut
{
    class NumberToWords
    {
        private int number;

        private static string[] _numbers =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

        private static string[] _teens =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private static string[] _tens =
        {
            "",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };
        
        private static string[] _thousands =
        {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion"
        };

        public NumberToWords()
        { }

        public NumberToWords(int _number)
        {
            this.number = _number;
        }

        public string Converter(int value)
        {
            string array, aux;
            bool thousands = false;
            bool zeros = true;

            StringBuilder output = new StringBuilder();
            array = value.ToString();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int digit = (int)(array[i] - '0');
                int col = (array.Length - (i + 1));

                switch (col % 3)
                {
                    case 0:
                        thousands = true;
                        if (i == 0)
                        {
                            aux = String.Format("{0} ", _numbers[digit]);
                        }
                        else if (array[i - 1] == '1')
                        {
                            aux = String.Format("{0} ", _teens[digit]);
                            i--;
                        }
                        else if (digit != 0)
                        {
                            aux = String.Format("{0} ", _numbers[digit]);
                        }
                        else
                        {
                            aux = String.Empty;
                            if (array[i - 1] != '0' || (i > 1 && array[i - 2] != '0'))
                                thousands = true;
                            else
                                thousands = false;
                        }

                        if (thousands)
                        {
                            if (col > 0)
                            {
                                aux = String.Format("{0}{1}{2}", aux, _thousands[col / 3], zeros ? " " : ", ");

                            }
                            zeros = false;
                        }
                        output.Insert(0, aux);
                        break;

                    case 1:
                        if (digit > 0)
                        {
                            aux = String.Format("{0}{1}", _tens[digit], (array[i + 1] != '0') ? "-" : " ");
                            output.Insert(0, aux);
                        }
                        break;

                    case 2:
                        if (digit > 0)
                        {
                            aux = String.Format("{0} hundred ", _numbers[digit]);
                            output.Insert(0, aux);
                        }
                        break;
                }
            }

            return output.ToString(0, output.Length - 1);
        }
    }
}
