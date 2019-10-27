using GoldDigger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class HarborTrack : Track
    {
        public Ship ship { get; set; }

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

        public override int ReceiveCart(Cart cart)
        {
            if (Cart == null)
            {
                Cart = cart;
                if(ship != null && ship.IsReady())
                {
                    ship.addLoad();
                }
                return 1;
            }

            return 2;
        }

        public override String getSymbol()
        {
            if (Cart == null)
            {
                if (Symbol == null)
                {
                    Symbol = "███";
                }
                return Symbol;
            }
            else
            {
                if (Cart.Full == true)
                {
                    return "ÜÜÜ";
                }
                return "UUU";
            }
        }
    }
}