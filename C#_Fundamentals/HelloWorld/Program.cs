using System;
using HouseFunction;
//Line comment example
/*
    Mutiple line comment example
    - C# uses PascelCase for the most part
    - We use camelCase for naming fields and variables
*/

namespace HelloWorld
{
    class Program
    {
        /*
            - Main method is the starting point for a C# program
            - static means: I don't have to instantiate the class to use the method/variable

        */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);
        }
    }
}
