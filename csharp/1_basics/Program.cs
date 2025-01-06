
using System;

namespace Basics {

    class Program {
        static void fnc(string name) {
            System.Console.WriteLine($"Name: {name}");
        }

        static int sum(int n1, int n2) {
            return n1+n2;
        }
        public static void Main(string[] args) {
            System.Console.WriteLine("Testing");
            // Variables and Basic I/O
            int num = 1;
            string name = "nobody";
            double value = 7.8;

            // input with null reference
            System.Console.WriteLine("Enter a number");
            string? input = Console.ReadLine();
            if (input != null)
                num = int.Parse(input);
            else
                System.Console.WriteLine("Null Input");
            System.Console.WriteLine($"{num} | {name} | {value}");

            // basic control flow
            if (num > 0)
                System.Console.WriteLine("Number is +ve");
            else if (num < 0)
                System.Console.WriteLine("Num is -ve");
            else if (num == 0)
                System.Console.WriteLine("Num is 0");
            
            // loops

            for (int i = 0; i < 10; i++)
                System.Console.WriteLine($"Count: {i} | Position: {i+1}");
            
            Random r = new Random();
            int rnd_num = r.Next(1, 10),
                itr = 0;
            System.Console.WriteLine("====|====|====|====");
            while (true) {
                rnd_num = r.Next(1, 10);
                System.Console.WriteLine($"Random: {rnd_num} | Iterator: {itr++}");
                if (rnd_num%2 == 0)
                    break;
            }
            System.Console.WriteLine("====|====|====|====");

            // usage of functions: static is used before functions because static functions don't need an object for usage
            fnc("Testing");

            System.Console.WriteLine($"Sum of {itr} & {rnd_num} is: {sum(itr, rnd_num)}");
        }
    }
}