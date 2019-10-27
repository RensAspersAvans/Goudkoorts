using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GoldDigger
{
    public class Controller
    {
        private static System.Timers.Timer timer;


        private Boolean _quitGame;

        public Controller()
        {
            //Maak een timer aan
            this.gameView = new GameView();
            this.game = new GameModel();
            
            timer = new System.Timers.Timer(1000); //1000 ms = 1 tick per seconde

            timer.Elapsed += new ElapsedEventHandler((source, e) => Tick()); //Roept Tick aan elke seconde
            timer.AutoReset = true;
            
            
        }
        public GameModel game
        {
            get; set;
        }

        public GameView gameView
        {
            get; set;
        }

        public void Run()
        {
            timer.Enabled = true;
            _quitGame = false;
            gameView.Show(ParseRailroad());
            InputView input = new InputView();
            while (!game.GameOver() && !_quitGame)
            {
                CheckInput(input);
            }
            Stop();
        }

        private void CheckInput(InputView input)
        {
            switch(input.AskInput())
            {
                case 's':
                    _quitGame = true;                    
                    break;
                case '1':
                    game.rm.Switch1.Switch();
                    break;
                case '2':
                    game.rm.Switch2.Switch();
                    break;
                case '3':
                    game.rm.Switch3.Switch();
                    break;
                case '4':
                    game.rm.Switch4.Switch();
                    break;
                case '5':
                    game.rm.Switch5.Switch();
                    break;
            }           
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
            gameView.Update(ParseRailroad());
        }

        public String[] ParseRailroad()
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

                String[] newLayerLooseStringArray= new String[k];

                Track memory = trackLayers[i];

                for (int q = 0; q < k; q++)
                {
                    newLayerLooseStringArray[q] = memory.getSymbol();
                    if (i == 9 || i == 12)
                    {
                        memory = memory.Previous;
                    }
                    else
                    {
                        memory = memory.Next;
                    }
                    
                }

                String newLayerString = ConvertArrayToString(newLayerLooseStringArray);
                StringLayers[i] = newLayerString;
            }

            return StringLayers;
        }

        public String ConvertArrayToString(String[] strarray)
        {
            StringBuilder stringbuilder = new StringBuilder();

            for (int i = 0; i < strarray.Length; i++)
            {
                stringbuilder.Append(strarray[i]);
            }
            return stringbuilder.ToString();
        }

    }
}