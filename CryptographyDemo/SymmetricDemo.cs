using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CryptographyDemo
{
    class SymmetricDemo
    {
        //A method that exclusive ors a message with an integer key in blocks of one character.
        public static string XOR(string message, int key)
        {
            //message to array of int
            int[] messagePieces = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
            {   //i-th integer     i-th character
                messagePieces[i] = message[i] ^ key;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                //cast back to characters via ascii
                sb.Append((char)(messagePieces[i]));
            }

            return sb.ToString();
        }

        
        public static string SymmetricEncrypt(string message, int key)
        {

            BitArray messageInBits = StringtoBits(message);

            BitArray Shuffled1 = shuffle1(messageInBits);
            
            string PrepForXOR = BitstoString(Shuffled1);

            return XOR(PrepForXOR, key);
        }

        public static string SymmetricDecrypt(string message, int key)
        {
            string xorEd = XOR(message, key);
            
            BitArray toUnShuffle = StringtoBits(xorEd);

            BitArray unshuffled = shuffle1(toUnShuffle);

            return BitstoString(unshuffled);
        }


        static BitArray StringtoBits(string message)
        {
            byte[] Bytes = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                Bytes[i] = (byte)message[i];
            }
            return new BitArray(Bytes);
        }

        static string BitstoString(BitArray bits)
        {
            byte[] temp = new byte[bits.Count / 8];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bits.Count/8; i ++)
            {
                BitArray charbits = new BitArray(8);
                for (int j = 0; j < 8; j++)
                {
                    charbits[j] = bits[i*8 + j];
                }
                charbits.CopyTo(temp, i);
                sb.Append((char)temp[i]);
            }

            return sb.ToString();
        }

        static BitArray shuffle1(BitArray input)
        {            
            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                bool temp = input[i];
                input[i] = input[length - 1 - i];
                input[length - 1 - i] = temp;
            }
            return input;
        }

    }
}
