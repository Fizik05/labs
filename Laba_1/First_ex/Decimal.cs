using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace First_ex
{
    public class Decimal
    {
        readonly int _numerator;
        readonly int _denominator;
        public int Numerator
        {
            get { return _numerator; }
        }
        public int Denominator
        {
            get { return _denominator; }
        }

        public Decimal(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Denominator can't be zero");
            }

            int minValue = Math.Min(Math.Abs(_numerator), Math.Abs(_denominator));
            int generalDenominator = 1;
            for (int i = minValue; i > 0; i--)
            {
                if (_numerator % i == 0 && _denominator % i == 0)
                {
                    generalDenominator = i;
                    break;
                }
            }

            _numerator = a / generalDenominator;
            _denominator = b / generalDenominator;

            if (_numerator < 0 && _denominator < 0)
            {
                _numerator *= -1;
                _denominator *= -1;
            }
            else if (_denominator < 0)
            {
                _denominator *= -1;
                _numerator *= -1;
            }
        }

        public override string ToString()
        {
            if (_denominator == 1)
            {
                return string.Format("{0}", _numerator);
            }
            else if (_numerator == _denominator) { return "1"; }

            else if (_numerator < 0 || _denominator < 0)
            {
                return string.Format("-{0}/{1}", Math.Abs(_numerator), Math.Abs(_denominator));
            }

            return string.Format("{0}/{1}", _numerator, _denominator);
        }

        public static Decimal operator +(Decimal a, Decimal b)
        {
            /*int fir = a.Denominator, sec = b.Denominator;
            int minDen = Math.Min(fir, sec);*/
            int generalDenominator = LCM(a.Denominator, b.Denominator);
            /*            while (generalDenominator % fir != 0 && generalDenominator % sec != 0) { generalDenominator += minDen; }*/

            int valA, valB;
            valB = generalDenominator;
            valA = a.Numerator * (generalDenominator / a.Denominator) + b.Numerator * (generalDenominator / b.Denominator);

            return new Decimal(valA, valB);
        }

        public static Decimal operator -(Decimal a, Decimal b)
        {
            /*int fir = a.Denominator, sec = b.Denominator;
            int minDen = Math.Min(fir, sec);*/
            int generalDenominator = LCM(a.Denominator, b.Denominator);

            int valA, valB;
            valB = generalDenominator;
            valA = a.Numerator * (generalDenominator / a.Denominator) - b.Numerator * (generalDenominator / b.Denominator);

            return new Decimal(valA, valB);
        }

        static int LCM(int a, int b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static bool operator >(Decimal a, Decimal b)
        {
            return (float)a.Numerator / (float)a.Denominator > (float)b.Numerator / (float)b.Denominator;
        }

        public static bool operator <(Decimal a, Decimal b)
        {
            return (float)a.Numerator / (float)a.Denominator < (float)b.Numerator / (float)b.Denominator;
        }

        public static bool operator ==(Decimal a, Decimal b)
        {
            return (float)a.Numerator / (float)a.Denominator == (float)b.Numerator / (float)b.Denominator;
        }

        public static bool operator !=(Decimal a, Decimal b)
        {
            return (float)a.Numerator / (float)a.Denominator != (float)b.Numerator / (float)b.Denominator;
        }
        /*public int Numerator { get; private set; }
        public int Denominator { get; private set; }*/
    }
}
