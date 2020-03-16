using System;
using System.Collections;
using System.Text;

namespace CryptographyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region XOR

            // Elementary XOR demonstration
            string message = "Hello world!";
            int key = 5;

            string Encrypted = SymmetricDemo.XOR(message, key);
            Console.WriteLine(Encrypted);

            string decrypted = SymmetricDemo.XOR(Encrypted, key);
            Console.WriteLine(decrypted);

            #endregion

            #region DiffieHelmen

            //Ian's secret number is 123456789
            MyDiffieHelmenKeyGenerator IansDiffie = new MyDiffieHelmenKeyGenerator(123456789);

            //Cole's secret number is 123456789
            MyDiffieHelmenKeyGenerator ColesDiffie = new MyDiffieHelmenKeyGenerator(987654321);

            ColesDiffie.ComputeKeyFromGiven(IansDiffie.ValueToGive());
            IansDiffie.ComputeKeyFromGiven(ColesDiffie.ValueToGive());

            var breakpoint = "breakpoint";


            #endregion


            #region Symmetric

            string encrypted = SymmetricDemo.SymmetricEncrypt(breakpoint, 5);
            Console.WriteLine(encrypted);
            string uncrypted = SymmetricDemo.SymmetricDecrypt(encrypted, 5);
            Console.WriteLine(uncrypted);
            var pointBreak = breakpoint;

            #endregion


        }


    }
}
