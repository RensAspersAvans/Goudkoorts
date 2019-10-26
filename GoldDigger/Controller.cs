using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class Controller
    {
        public GameModel GameModel
        {
            get => default;
            set
            {
            }
        }

        public void startGame()
        {

            GameModel game = new GameModel();
        }
    }
}