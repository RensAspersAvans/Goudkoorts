using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class HarborTrack : Track
    {
        public override Boolean MoveCartForward()
        {
            if (Next == null)
            {
                Cart.cur_track = null;
                this.Cart = null;
                return true;
            }
            int i = Next.ReceiveCart(Cart);
            if (i == 1)
            {
                Cart.cur_track = Next;
                this.Cart = null;
                return true;
            }
            return false;

        }

        public override char getSymbol()
        {
            if (Cart == null)
            {
                if (Symbol.Equals(null))
                {
                    Symbol = '█';
                }
                return Symbol;
            }
            else
            {
                if (Cart.Full == true)
                {
                    return 'Ü';
                }
                return 'U';
            }
        }
    }
}