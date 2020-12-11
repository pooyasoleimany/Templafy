using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            var lastNode = new Node(1);
            var root = lastNode;

            var n = lastNode;

            while (n != null)
            {
                Console.WriteLine(n.Data);
                n = n.Previous();
            }


        }





    }
}
