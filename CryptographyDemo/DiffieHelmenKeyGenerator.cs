using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyDemo
{
    class MyDiffieHelmenKeyGenerator
    {
        public int Base = 413158511;
        public int Prime = 433024223;
        private int MySecretValue;
        //private static int OtherSecretValue = 987654321;
        private int Key;
        public MyDiffieHelmenKeyGenerator(int SecretVal)
        {
            MySecretValue = SecretVal;
        }
        
        // This method computes the partial value to hand to someone else. 
        public int ValueToGive()
        {
            return (int)Math.Pow(Base,MySecretValue) % Prime;
        }

        // This method computes the key based on the value given by the other party. 
        public void ComputeKeyFromGiven(int M)
        {
            Key = (int)Math.Pow(M, MySecretValue) % Prime;
        }

    }
}
