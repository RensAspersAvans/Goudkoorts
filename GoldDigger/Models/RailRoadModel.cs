using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoldDigger
{
    public class RailRoadModel
    {
        public Track[] Warehouses = new Track[3];
        public List<Cart> carts = new List<Cart>();

        public SwitchBackward Switch1 { get; set; }
        public SwitchForward Switch2 { get; set; }
        public SwitchBackward Switch3 { get; set; }
        public SwitchForward Switch4 { get; set;}
        public SwitchBackward Switch5 { get; set; }

        public Track[] Layers { get; set; }

        public RailRoadModel()
        {
            GenerateRailRoad();
        }

        public void GenerateRailRoad()
        {
            Track lastCreated;
            Layers = new Track[15];

            Switch1 = new SwitchBackward();
            Layers[2] = Switch1;                    //layer 3 + 3

            lastCreated = new StandardTrack();
            lastCreated.Previous = Switch1;
            Switch1.Next = lastCreated;
            Switch2 = new SwitchForward();
            Switch2.Previous = lastCreated;
            lastCreated.Next = Switch2;


            Warehouses[0] = new StandardTrack();
            Layers[0] = Warehouses[0];              //layer 1 + 4
            lastCreated = Warehouses[0];

            for (int i = 0; i < 3; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            lastCreated.Next = Switch1;
            Switch1.SecondPrevious = lastCreated;

            Warehouses[1] = new StandardTrack();
            Layers[1] = Warehouses[1];                  //layer 2 + 4
            lastCreated = Warehouses[1];

            for (int i = 0; i < 3; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            lastCreated.Next = Switch1;
            Switch1.Previous = lastCreated;

            Warehouses[2] = new StandardTrack();
            lastCreated = Warehouses[2];

            Layers[6] = Warehouses[2];             //layer 7 + 7

            for (int i = 0; i < 6; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            Switch3 = new SwitchBackward();
            Switch3.Previous = lastCreated;
            lastCreated.Next = Switch3;
            Layers[7] = Switch3;                        //layer 8 + 3

            lastCreated = new StandardTrack();
            lastCreated.Previous = Switch3;
            Switch3.Next = lastCreated;

            Switch4 = new SwitchForward();
            Switch4.Previous = lastCreated;
            lastCreated.Next = Switch4;

            lastCreated = new StandardTrack();
            Layers[8] = lastCreated;                    //layer 9 + 4
            lastCreated.Previous = Switch4;
            Switch4.SecondNext = lastCreated;

            for (int i = 0; i < 4; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            Layers[13] = lastCreated;                   //layer 14 + 1

            for (int i = 0; i < 3; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            for (int i = 0; i < 8; i++)
            {
                lastCreated.Next = new YardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            Layers[9] = lastCreated;                    //layer 10 + 11

            lastCreated = new StandardTrack();
            lastCreated.Previous = Switch2;
            Switch2.SecondNext = lastCreated;

            Layers[4] = lastCreated;                    //layer 5 + 2

            lastCreated.Next = new StandardTrack();
            lastCreated.Next.Previous = lastCreated;
            lastCreated = lastCreated.Next;

            lastCreated.Next = Switch3;
            Switch3.SecondPrevious = lastCreated;

            lastCreated = new StandardTrack();
            Layers[14] = lastCreated;                   //layer 15 + 2
            lastCreated.Previous = Switch4;
            Switch4.Next = lastCreated;

            lastCreated.Next = new StandardTrack();
            lastCreated.Next.Previous = lastCreated;
            lastCreated = lastCreated.Next;

            Switch5 = new SwitchBackward();
            lastCreated.Next = Switch5;
            Switch5.Previous = lastCreated;

            lastCreated = new StandardTrack();
            Layers[3] = lastCreated;                    //layer 4 + 5
            lastCreated.Previous = Switch2;
            Switch2.Next = lastCreated;

            for (int i = 0; i < 4; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            lastCreated.Next = Switch5;
            Switch5.SecondPrevious = lastCreated;

            Layers[5] = Switch5;                          //layer 6 + 3
            lastCreated = Switch5;
            for (int i = 0; i < 3; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            Layers[10] = lastCreated;                    //layer 11 + 1

            lastCreated.Next = new StandardTrack();
            lastCreated.Next.Previous = lastCreated;
            lastCreated = lastCreated.Next;

            Layers[11] = lastCreated;                   //layer 12 + 1

            for (int i = 0; i < 2; i++)
            {
                lastCreated.Next = new StandardTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            for (int i = 0; i < 10; i++)
            {
                lastCreated.Next = new HarborTrack();
                lastCreated.Next.Previous = lastCreated;
                lastCreated = lastCreated.Next;
            }

            Layers[12] = lastCreated;                   //layer 13 + 12

        }

        internal void AddCart()
        {
            Random rnd = new Random();

            int spawnchange = rnd.Next(0, 1);

            int i = rnd.Next(1, 3);

            Cart c = new Cart();

            Warehouses[i - 1].Cart = c;
            c.cur_track = Warehouses[i];
            carts.Add(c);
            Debug.WriteLine("cart added");
        }

        public Boolean MoveCarts()
        {
            foreach(var cart in carts)
            {
                if (!cart.MoveForward())
                {
                    return false;
                }
            }

            return true;
        }
    }
}