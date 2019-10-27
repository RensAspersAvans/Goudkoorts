using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class YardTrack : Track
    {
        public override String getSymbol()
        {
            if (Cart == null)
            {
                if (Symbol == null)
                {
                    Symbol = "___";
                }
                return Symbol;
            }
            else
            {
                return "ÜÜÜ";
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