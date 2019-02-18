/*
 * Prime number utils.
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * 
 * Miller-Rabin primality test, but we're not using it here.
 * https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test
*/
using System;

namespace LongRandomNumber
{
    class LongRandomNumber
    {
        /// <summary>
        /// Demonstrating the methods in here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(GetLongPrime(false));
        }
        /// <summary>
        /// Make up a random long int that's prime. This will take a few seconds
        /// </summary>
        /// <param name="verbose">True to generate some debugging output</param>
        /// <returns></returns>
        public static long GetLongPrime(Boolean verbose)
        {
            long n1 = 0, n2 = 0, n3 = 0, random = 0;
            Random r = new Random();
            while (true)
            {
                n1 = r.Next();
                n2 = r.Next();
                n3 = (long)(n1 << 31);
                random = Math.Abs(n3 + n2);
                if (verbose) { Console.Write(n1 + "\n" + n2 + "\n" + n3 + "\n" + random); }
                if (IsRandom(random)) break;
            }
            return random;
        }
        /// <summary>
        /// Prime checker. Brute Force.
        /// </summary>
        /// <param name="number">Number to check</param>
        /// <returns>True if number is prime</returns>
        private static Boolean IsRandom(long number)
        {
            Boolean random = true;
            if (number % 2 == 0) { return false; }
            long limit = (long)Math.Sqrt(number);

            for (long i = 3; i <= limit; i += 2)
            {
                if (number % i == 0) { random = false; break; }
            }
            return random;
        }
    }
}
