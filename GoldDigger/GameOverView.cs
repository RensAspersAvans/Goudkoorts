using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    class GameOverView
    {
        public GameOverView()
        {
            Console.Clear();                       
        }

        public void Show(int score)
        {
            ShowGameOverText();
            ShowScore(score);
        }

        public void ShowGameOverText()
        {
            Console.WriteLine("G A M E  O V E R");
            Console.WriteLine();
        }

        public void ShowScore(int score)
        {
            Console.WriteLine("Score:  " + score);
        }
    }


    
}
