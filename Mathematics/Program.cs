using System;

namespace Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // SEIVE OF ERATA STENES
            // bool[] primes = SeiveOfEratoStenes(20);
            // for(int i = 0; i < primes.Length; i++)
            //     Console.WriteLine(i + " " + primes[i]);

            // GCD
            // Console.WriteLine(GCD(15, 27));
            //Console.WriteLine(GCD(24, 60));
            //Console.WriteLine(GCD(270, 192));

            // Console.WriteLine(FastPower(3, 5));
            // Console.WriteLine(FastPowerModule(3978432, 5, 1000000007));

            //printNos(3);

            BitMaskOperations();
        }

        static void BitMaskOperations() {
            BitMasking bit = new BitMasking();
            // Find the value of ith bit of a given number
            //bit.Find_Ith_Bit(309, 5);

            // Set the ith bit to 1 of a given number
            //bit.Set_Ith_Bit(309, 3);

            // Clear the ith bit of a given number (change ith bit to 0)
            //bit.Clear_Ith_Bit(309, 4); 

            // Find number of bits to change from number a to number b
            bit.FindCountOfBitsToChange(22, 27);
        }

        static void printNos( int n)
        {
            //Your code here
            printNum(1, n);
        }
        
        static void printNum(int num, int target) {
            if (num > target) {
                return;
            }
            
            Console.WriteLine(num + " ");
            printNum(++num, target);
        }

        /*
        FAST POWER
        a raise b -> fast way to achieve the result
        */
        static int FastPower(int a, int b) {
            int res = 1;

            while (b > 0) {
                // Odd number
                if ((b & 1) != 0) { // Same as (b % 2 != 0)
                    res = res * a;
                }

                a = a* a;
                b = b >> 1; // Same as b/2;
            }

            return res;
        }

        /*
        MODULO ARITHMETICS  
        If we need to find the power of a big number & pass a int, int wil lresult in Overflow
        To handle big numbers, we use Module along with FastPower

        #Principle:
        (a + b) % n = (a % n + b % n) % n
        (a * b) % n = (a % n * b % n) % n
        (a - b) % n = (a % n - b % n) % n
        */
        static long FastPowerModule(long a, long b, int n) {
            long res = 1;

            while (b > 0) {
                // Odd number
                // Bit cal of last bit of b & 1
                // b % 2 -> takes times & memory, bit calc is way faster
                if ((b & 1) != 0) { // Same as (b % 2 != 0)
                    res = (res * a % n) % n;
                }

                a = (a % n * a % n) % n;
                b = b >> 1; // Same as b/2; Shift is again bit calc, faster than division
            }

            return res;
        }

        /*
        GCD
        */
        static int GCD(int a, int b) {
            Console.WriteLine("a = " + a + " b = " + b);
            if (b == 0)
                return a;
            
            return GCD(b, a%b);

        }

        /*
        PRIME NUMBERS
        Find the number of Prime numbers from 1 to N.
        In this algorithm, you don't have to iterate thru all number till n
        Instead you only iterate from 2 to sqrt(N) and you have got all the prime number in the range
        */
        static bool[] SeiveOfEratoStenes(int n) {

            // Make n+1 size, so no need to work with n-1
            bool[] primes = new bool[n+1];

            // Mark each bool as true
            Array.Fill(primes, true);
            // Mark 0 & 1 as false, as they are not a prime number
            primes[0] = false;
            primes[1] = false;
            
            // Iterate from 2 to n while (i * i) -> (4*4 = 16), square of i <= n
            for(int i = 2; i * i <= n; i++) {

                // Jump by adding j i times - i = 3, j = 2*3 6; ; j = 6+3=9
                for (int j = 2*i; j <= n; j += i) {
                    primes[j] = false;
                }                
            }



            return primes;
        }
    }
}
