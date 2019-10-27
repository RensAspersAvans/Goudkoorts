using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class InputView
    {
        public char AskInput()
        {
            
            char keyPressed = Console.ReadKey().KeyChar;
            return keyPressed;
        }


    }
}