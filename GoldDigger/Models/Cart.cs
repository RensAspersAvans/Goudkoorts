using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class Cart
    {
        public Track cur_track { get; set; } 
        public Boolean Full { get; set; }

        public Boolean MoveForward()
        {
            if (cur_track == null)
            {
                return true;
            }
            else
            {
                return cur_track.MoveCartForward();
            }
        }
    }
}