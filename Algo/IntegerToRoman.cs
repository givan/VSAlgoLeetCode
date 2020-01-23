using System.Text;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/integer-to-roman/
    // Difficulty: Medium
    /*
    Symbol       Value
I             1
IV            4
V             5
IX            9
X             10
XL            40
L             50
XC            90
C             100
CD            400
D             500
CM            900
M             1000

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.

    */
    public class IntegerToRoman
    {
        private static readonly string[] ROMAN_THOUSANDS = { "", "M", "MM", "MMM" };
        private static readonly string[] ROMAN_HUNDREDS = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static readonly string[] ROMAN_TENS = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static readonly string[] ROMAN_ONES = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        private void AddRomanNumber(ref int number, int romanDecimalNumber, string romanNumber, StringBuilder sbCurrentRomanNumber)
        {
            while (number >= romanDecimalNumber)
            {
                sbCurrentRomanNumber.Append(romanNumber);
                number -= romanDecimalNumber;
            }
        }

        public string IntToRomanV3(int num)
        {
            if (num <= 0 || num >= 4000) { return ""; }

            string thousands = ROMAN_THOUSANDS[num / 1000];
            num %= 1000; // now num is between 0 and 999

            string hundreds = ROMAN_HUNDREDS[num / 100];
            num %= 100; // now num is between 0 and 99

            string tens = ROMAN_TENS[num / 10];
            num %= 10; // now num is between 0 and 9

            string ones = ROMAN_ONES[num];

            string romanNumber = $"{thousands}{hundreds}{tens}{ones}";
            return romanNumber;
        }

        public string IntToRomanV2(int num)
        {
            if (num <= 0 || num > 4000) { return ""; }

            StringBuilder sbRomanNumber = new StringBuilder();

            AddRomanNumber(ref num, 1000, "M", sbRomanNumber);
            AddRomanNumber(ref num, 900, "CM", sbRomanNumber);
            AddRomanNumber(ref num, 500, "D", sbRomanNumber);
            AddRomanNumber(ref num, 400, "CD", sbRomanNumber);
            AddRomanNumber(ref num, 100, "C", sbRomanNumber);
            AddRomanNumber(ref num, 90, "XC", sbRomanNumber);
            AddRomanNumber(ref num, 50, "L", sbRomanNumber);
            AddRomanNumber(ref num, 40, "XL", sbRomanNumber);
            AddRomanNumber(ref num, 10, "X", sbRomanNumber);
            AddRomanNumber(ref num, 9, "IX", sbRomanNumber);
            AddRomanNumber(ref num, 5, "V", sbRomanNumber);
            AddRomanNumber(ref num, 4, "IV", sbRomanNumber);
            AddRomanNumber(ref num, 1, "I", sbRomanNumber);

            return sbRomanNumber.ToString();
        }
        public string IntToRoman(int num)
        {
            if (num <= 0 || num >= 4000) { return ""; }

            StringBuilder sbRomanNumber = new StringBuilder();

            if (num >= 1000)
            {
                int thousands = num / 1000;
                sbRomanNumber.Append(new string('M', thousands));

                num -= thousands * 1000;
            }

            if (num >= 900)
            {
                sbRomanNumber.Append("CM");

                num -= 900;
            }

            if (num >= 500)
            {
                sbRomanNumber.Append("D");

                num -= 500;
            }

            if (num >= 400)
            {
                sbRomanNumber.Append("CD");

                num -= 400;
            }

            if (num >= 100)
            {
                int hundreds = num / 100;
                sbRomanNumber.Append(new string('C', hundreds));

                num -= hundreds * 100;
            }

            if (num >= 90)
            {
                sbRomanNumber.Append("XC");

                num -= 90;
            }

            if (num >= 50)
            {
                sbRomanNumber.Append("L");

                num -= 50;
            }

            if (num >= 40)
            {
                sbRomanNumber.Append("XL");
                num -= 40;
            }

            if (num >= 10)
            {
                int tens = num / 10;
                sbRomanNumber.Append(new string('X', tens));

                num -= tens * 10;
            }

            if (num >= 9)
            {
                sbRomanNumber.Append("IX");
                num -= 9;
            }

            if (num >= 5)
            {
                sbRomanNumber.Append("V");

                num -= 5;
            }

            if (num == 4)
            {
                sbRomanNumber.Append("IV");

                num = 0;
            }

            if (num > 0)
            {
                int ones = num;
                sbRomanNumber.Append(new string('I', ones));
            }

            return sbRomanNumber.ToString();
        }
    }
}