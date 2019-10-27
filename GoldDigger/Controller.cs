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

            timer.Elapsed += new ElapsedEventHandler((source, e) => Tick()); //Roept Tick aan elke seconde
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

        public void Run()
        {
            timer.Enabled = true;           
        }

        private void Stop()
        {
            timer.Enabled = false;
            GameOverView endScreen = new GameOverView();            
            endScreen.Show(game.GetScore());
        }

        public void Tick()
        {
            game.Update();
            
            if(game.GameOver())
            {
                Stop();
            }            
        }

        public void ParseRailroad()
        {
            Track[] trackLayers = game.GetLayers();
            String[] StringLayers = new String[15];
            int k = 0;

            for (int i = 0; i < trackLayers.Length; i++)
            {
                switch (i) {
                    case 0:
                        k = 4;
                        break;
                    case 1:
                        k = 4;
                        break;
                    case 2:
                        k = 3;
                        break;
                    case 3:
                        k = 5;
                        break;
                    case 4:
                        k = 2;
                        break;
                    case 5:
                        k = 3;
                        break;
                    case 6:
                        k = 7;
                        break;
                    case 7:
                        k = 3;
                        break;
                    case 8:
                        k = 4;
                        break;
                    case 9:
                        k = 11;
                        break;
                    case 10:
                        k = 1;
                        break;
                    case 11:
                        k = 1;
                        break;
                    case 12:
                        k = 12;
                        break;
                    case 13:
                        k = 1;
                        break;
                    case 14:
                        k = 2;
                        break;
                }

                Char[] newLayerCharArray= new Char[k];

                Track memory = trackLayers[i];

                for (int q = 0; q < k; q++)
                {
                    newLayerCharArray[q] = memory.getSymbol();
                    memory = memory.Next;
                }

                String newLayerString = newLayerCharArray.ToString();
                StringLayers[i] = newLayerString;
            }
        }

        

    }
}