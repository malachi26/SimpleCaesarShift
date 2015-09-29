using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCeasarShift
{
    public static class ShiftExtensions
    {
        public static string RemoveSpaces(this string plainIn)
        {
            return plainIn.Replace(" ", string.Empty);
        }
        public static string Reverse(this string plainIn)
        {
            char[] charArray = plainIn.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
    public class ShiftCipher
    {
        private const int LETTERA = (int)'A';
        private const int LETTERZ = (int)'Z';
        private const int LETTERCOUNT = (int)'Z' - LETTERA + 1;

        public string Shift(string plainIn, int shift)
        {// 65=a 90=z in ASCII
            string readOut = string.Empty;
            var input = plainIn.ToLower();
            char[] charArray = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                int Num = Convert.ToInt32(charArray[i]) + shift;
                readOut += Convert.ToChar(Num > 90 ? Num -= 26 : (Num < 65 ? Num += 26 : Num));
                //readOut += Convert.ToChar(Num > LETTERZ ? Num -= LETTERCOUNT : (Num < LETTERA ? Num += LETTERCOUNT : Num));
            }
            return readOut;
        }

        //this method will take all of these methods and put them together to encrypt
        public string Encrypt(string readIn, int amountOfShift)
        {
            readIn = readIn.RemoveSpaces();
            readIn = Shift(readIn, amountOfShift).ToUpper().Reverse();
            return readIn;
        }

        public string Decrypt(string readIn, int amountOfShift)
        {
            readIn = Shift(readIn, -amountOfShift).Reverse(); // undo the reverse by running the method again
            return readIn;
        }       
    }
}