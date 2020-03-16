using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyDemo
{
    class MyDiffieHelmenKeyGenerator
    {
        //https://primes.utm.edu/lists/2small/100bit.html

        public int Base = (int)Math.Pow(2, 129)-25;
        public int Prime = (int)Math.Pow(2, 129) - 315;

        private int MySecretValue;
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
