using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3CSharp
{
    class Number
    {
        private int ones;
        private int tens;
        private int hundreds;
        private int thousands;

        public Number(int ones, int tens, int hundreds, int thousands)
        {
            this.ones = ones;
            this.tens = tens;
            this.hundreds = hundreds;
            this.thousands = thousands;
        }

        public Number()
        {
            Random rand = new Random();
            this.ones = rand.Next(10);
            this.tens = rand.Next(10);
            this.hundreds = rand.Next(10);
            this.thousands = rand.Next(10);
        }

        public Number(int DecNumber)
        {
            this.ones = DecNumber % 10;
            this.tens = DecNumber % 100 / 10;
            this.hundreds = DecNumber % 1000 / 100;
            this.thousands = DecNumber / 1000;
        }

        public Number(Number number)
        {
            this.ones = number.GetOnes();
            this.tens = number.GetTens();
            this.hundreds = number.GetHundreds();
            this.thousands = number.GetThousands();
        }

        public int GetOnes()
        {
            return ones;
        }

        public int GetTens()
        {
            return tens;
        }

        public int GetHundreds()
        {
            return hundreds;
        }

        public int GetThousands()
        {
            return thousands;
        }

        public int ReturnDecimalEquivalent()
        {
            int result = thousands * 1000 + hundreds * 100 + tens * 10 + ones;
            return result;
        }

        public static Number operator +(Number a, Number b)
        {
            int cOnes = a.GetOnes() + b.GetOnes();
            int cTens = a.GetTens() + b.GetTens();
            int cHundreds = a.GetHundreds() + b.GetHundreds();
            int cThousands = a.GetThousands() + b.GetThousands();
            Number c = new Number(cOnes, cTens, cHundreds, cThousands);
            c.UpdateNumberToItsBoundaries();
            return c;
        }

        public static Number operator ++(Number a)
        {
            a.ones++;
            a.tens++;
            a.hundreds++;
            a.thousands++;
            a.UpdateNumberToItsBoundaries();
            return a;
        }

        public static Number operator --(Number a)
        {
            a.ones--;
            a.tens--;
            a.hundreds--;
            a.thousands--;
            a.UpdateNumberToItsBoundaries();
            return a;
        }

        public static bool operator <(Number a, Number b)
        {
            if (a.ReturnDecimalEquivalent() < b.ReturnDecimalEquivalent())
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Number a, Number b)
        {
            if (a.ReturnDecimalEquivalent() > b.ReturnDecimalEquivalent())
            {
                return true;
            }
            return false;
        }


        public void UpdateNumberToItsBoundaries()
        {
            if (ones < 0)
            {
                ones = 0;
            }
            if (tens < 0)
            {
                tens = 0;
            }
            if (hundreds < 0)
            {
                hundreds = 0;
            }
            if (thousands < 0)
            {
                thousands = 0;
            }

            if (ones > 9)
            {
                tens += ones / 10;
                ones %= 10;
            }
            if (tens > 9)
            {
                hundreds += tens / 10;
                tens %= 10;
            }
            if (hundreds > 9)
            {
                thousands += hundreds / 10;
                hundreds %= 10;
            }
            if (thousands > 9)
            {
                ones = 9;
                tens = 9;
                hundreds = 9;
                thousands = 9;
            }
        }

    }
}
