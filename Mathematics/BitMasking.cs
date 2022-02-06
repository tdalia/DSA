using System;

namespace Mathematics
{
    class BitMasking
    {
        // Is number even or odd
        public static int isEven(int n) {
            // If Bitwise n & 1 == 0, number is even, else odd
            if ((n & 1) == 0) {
                return 1; // true
            }
            
            return 0;   // false
        }

        // Find the Count of trailing zeros in binary representation of the given number
        // Eg. Bin of 8 = 1000, thus the # of trailing zeros is 3
        // 18 = 10010, # of trailing zeros is 1
        public int TrailingZeros(int A) {
            int count = 0;
                    
            while ((A & 1) == 0) {
                A = A >> 1;
                count++;
            }

            return count;
        }

        // Find the ith bit 
        // A number is stored as bits (0 & 1). An int is a 32 bit. We need to find if the
        // ith bit of that number is 0 or 1
        public void Find_Ith_Bit(int number, int i) {
            /* Suppose, we need to find the 5th bit of a number - the 5th bit, is 1 or 0
            number in bits is 
            num -  100110101   (8 bit - 0 to 8 indicies)
            mask - 000100000   (1 5 times, so 1 on 5th bit)
                 -----------
            &    = 000100000  (on 5th bit, the value is 1, 1&1 == 1, so that
                                tells us that on 5th position, the value is 1)
            */
            // Find Mask
            // Left shift 1 i times
            int mask = 1 << i;

            // Do bitwise & operation on number & mask
            if ((number & mask) == 0) 
                Console.WriteLine($"{i}th bit of number {number} contains 0");
            else 
                Console.WriteLine($"{i}th bit of number {number} contains 1");
        }

        // Set the ith bit of a number to the specified value
        // Suppose, Binary number = 100110101 == 309
        // Set the 3rd bit to 1 ==> 100111101 == 317
        public void Set_Ith_Bit(int number, int i) {

            // 1) Create the mask. Since we want to set the ith bit, so
            //    left shift 1 i times
            int mask = 1 << i;

            // 2) Do OR on number & mask
            // This will do OR on bits of both values & give the new result
            int result = (number | mask);

            Console.WriteLine($"After setting the {i} bit as 1 to {number}, the result is {result}");
        }

        // Clear ith bit - change the ith bit from 1 to 0
        // Suppose, Binary number =   100110101 == 309
        // Clear the 4rd bit to 0 ==> 100100101 == 293
        public void Clear_Ith_Bit(int number, int i) {
            /* Logic
            We need to find a mask where all bits are 1 except the ith, that should be 0
            Then, do & on mumber & mask, that will result in changing the ith bit to 0
            If ith bit value is 1, then 1 & 0 == 0, 0 & 0 == 0 
            So in anyways, if it is 1, then it will be cleared i.e. set to 0
            */

            // Mask -> left shift 1 i times & then invert it
            /*
            1 << i ==> 000010000
            ~      ==> 111101111   // we got 0 at the ith position for masking
            number ==> 100110101
            &      ==> 100100101  RESULT         
            */
            int mask = ~(1 << i);   // Left shift 1 i times & inverse of it
            int result = (number & mask);

            Console.WriteLine($"After clearing the {i} bit of {number}, the result is {result}");
        }

        /*
        Find number of bits to change from number a to b
        We have a number "a" to change that into, how many bits will we have to change?
        a -> 10110 == 22
        b -> 11011 == 27
              11 1 == 3 bits to change is the ans 
        */
        public void FindCountOfBitsToChange(int fromNum, int toNum) {
            // To find # of bits to change, we need to know how many bits are different
            // XOR return 1 when both bits have differnt values
            int changedVal = (fromNum ^ toNum);

            // We got differnce in bits from the 2 numbers. 
            // Now, find # of 1's present in this changedVal -> that many bits we got to cahnge
            int count = 0;
            while(changedVal != 0) {
                // n = n & (n-1) --> changes the least significant bit (1) to 0
                // We keep on doing this, until we reach 0, that has all bits as 0
                changedVal = (changedVal & (changedVal - 1));
                count++;
            }

            Console.WriteLine($"Number of bits to change {fromNum} to {toNum} is {count} times.");
        }
    }
}