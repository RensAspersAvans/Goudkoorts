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
        public Char Symbol { get; set; }


        public Boolean ReceiveCart(Cart cart)
        {
            if(Cart == null)
            {
                Cart = cart;
                return true;
            }

            return false;

            
        }
        
    }
}