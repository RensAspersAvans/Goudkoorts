using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class InputView
    {
        public char AskInput()
        {
            Console.WriteLine("     1 - 5:   Verander switch 1 - 5 van richting.");
            Console.WriteLine("     S:       Stop met spelen.");
            char keyPressed = Console.ReadKey().KeyChar;
            return keyPressed;
        }


    }
}