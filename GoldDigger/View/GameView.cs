﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoldDigger
{
    public class GameView
    {
        

        

        public void Update()
        {
            //laat alle layers zien
            //laat daaronder de controls zien
            
        }

        public void Show(String[] layers)
        {
            Console.Clear();

            Console.WriteLine(layers[12]);
            Console.WriteLine("                                 " + layers[11]);
            Console.WriteLine(layers[0] + "   " + layers[3] + "   " + layers[10]);
            Console.WriteLine("         " + layers[2] + "         " + layers[5]);
            Console.WriteLine(layers[1] + "   " + layers[4] + "   " + layers[14]);
            Console.WriteLine("                  " + layers[7]);
            Console.WriteLine(layers[6] + "   " + layers[8] );
            Console.WriteLine("                                 " + layers[13]);
            Console.WriteLine("   " + layers[9]);
            Debug.WriteLine("screen updated");
        }
    }


   
}