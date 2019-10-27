using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoldDigger
{
    public class GameView
    {
        

        

        public void Update(String[] layers)
        {
            Console.Clear();
            Console.WriteLine("         ");
            Console.Write("");


            Console.WriteLine(layers[12]);
            Console.WriteLine("                                 " + layers[11]);
            Console.WriteLine(layers[0] + "   " + layers[3] + "   " + layers[10]);
            Console.WriteLine("         " + layers[2] + "         " + layers[5]);
            Console.WriteLine(layers[1] + "   " + layers[4] + "   " + layers[14]);
            Console.WriteLine("                  " + layers[7]);
            Console.WriteLine(layers[6] + "   " + layers[8]);
            Console.WriteLine("                                 " + layers[13]);
            Console.WriteLine("   " + layers[9]);

            Console.WriteLine();

            Console.WriteLine("     1 - 5:   Verander switch 1 - 5 van richting.");
            Console.WriteLine("     S:       Stop met spelen.");
        }

        public void ShowScoreBoard(int score)
        {
            Console.WriteLine("SCORE:  " + score);
            //tijd?
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