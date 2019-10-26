using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class SwitchForward : Track
    {
        public Track SecondNext { get; set; }

        public SwitchForward()
        {
            Symbol = '/';
        }


        public void Switch()
        {
            if (Cart == null)
            {
                Track memory = Next;
                Next = SecondNext;
                SecondNext = memory;
                if (Symbol.Equals('/'))
                {
                    Symbol = '\\';
                }
                else
                {
                    Symbol = '/';
                }
            }


        }
    }
}