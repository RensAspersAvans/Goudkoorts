using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GoldDigger
{
    public class Controller
    {
        private static System.Timers.Timer timer;

        public Controller()
        {
            //Maak een timer aan
            
            timer = new System.Timers.Timer(1000); //1000 ms = 1 tick per seconde

            timer.Elapsed += new ElapsedEventHandler((source, e) => Tick());
            timer.AutoReset = true;
            
        }
        public GameModel game
        {
            get => default;
            set
            {
            }
        }

        public GameView gameView
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        public void Run()
        {
            timer.Enabled = true;           
        }

        private void Stop()
        {
            timer.Enabled = false;
            GameOverView endScreen = new GameOverView();
            endScreen.Show(-1);
            //endScreen.Show(game.GetScore());
        }

        public void Tick()
        {
            //game.update();
            
            if(game.GameOver())
            {
                Stop();
            }

            
        }

        
=======
        public void startGame()
        {

            GameModel game = new GameModel();
        }
>>>>>>> bdda1ebba343ee0067b96ee7c6282acd7b195b26
    }
}