using System;

namespace GoldDigger
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.WriteLine("     1 - 5:   Verander switch 1 - 5 van richting");
                Console.WriteLine("     S:       Stop met spelen");

            new Controller().Run();
            
        }
    }
}
