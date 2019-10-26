using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class YardTrack : Track
    {
        public override Char getSymbol()
        {
            if (Cart == null)
            {
                if (Symbol.Equals(null))
                {
                    Symbol = '_';
                }
                return Symbol;
            }
            else
            {
                return 'Ü';
            }
        }

        public override Boolean MoveCartForward()
        {
            if (Next == null)
            {
                return true; ;
            }
            int i = Next.ReceiveCart(Cart);
            if (i == 1)
            {
                Cart.cur_track = Next;
                this.Cart = null;
                return true;
            }
            else
            {
                return true;
            }
            

        }
    }
}