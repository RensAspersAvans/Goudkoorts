using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public abstract class Track
    {
        public Track Next { get; set; }
        public Track Previous { get; set; }
        public Cart Cart { get; set; }
        public Char Symbol{ get; set; }


        

        public virtual Char getSymbol()
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
                return 'Ü';
            }
        }


        public virtual int ReceiveCart(Cart cart)
        {
            if(Cart == null)
            {
                Cart = cart;
                return 1;
            }

            return 2; 
        }

        public virtual Boolean MoveCartForward()
        {
            if (Next == null)
            {
                return false;
            }
            int i = Next.ReceiveCart(Cart);
            if (i == 1)
            {
                Cart.cur_track = Next;
                this.Cart = null;
                return true;
            }
            if (i == 3)
            {
                return true;
            }
            return false;
            
        }
        
    }
}