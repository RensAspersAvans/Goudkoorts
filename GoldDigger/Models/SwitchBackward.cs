using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class SwitchBackward : Track
    {
        public Track SecondPrevious { get; set; }

        public SwitchBackward()
        {
            Symbol = "///";
        }

        public override int ReceiveCart(Cart cart)
        {
            if (cart == null)
            {
                if (cart.cur_track == Previous)
                {
                    Cart = cart;
                    return 1;
                }
                return 3;
            }

            return 2;
        }

        public void Switch()
        {
            if (Cart == null)
            {
                Track memory = Previous;
                Previous = SecondPrevious;
                SecondPrevious = memory;
                if (Symbol.Equals("///"))
                {
                    Symbol = "\\\\";
                }
                else
                {
                    Symbol = "///";
                }
            }
            

        }


    }
}