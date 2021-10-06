using System.Collections.Generic;
using System;
namespace CollectionFunction
{
    public class Collection
    {
        List<string> strings = new List<string>();
        public Collection()
        {
        }

        public void CollectionMain()
        {
            Console.WriteLine("===== Collection Demo ====");
            Console.WriteLine("List Demo");

            strings.Add("First element");
            strings.Add("Second element");
            strings.Add("Third element");

            Console.WriteLine("===Foreach Demo===");
            foreach (string item in strings)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("===For loop Demo===");
            for (int i = 0; i < strings.Count; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }
    }
}