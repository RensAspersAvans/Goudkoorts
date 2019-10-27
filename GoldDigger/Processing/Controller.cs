using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GoldDigger
{
    public class Controller
    {
        private static System.Timers.Timer timer;
        int TickCount;
        

        private Boolean _quitGame;

        public Controller()
        {
            //Maak een timer aan
            this.gameView = new GameView();
            this.game = new GameModel();
            WaitTicksCount = 6;
            timer = new System.Timers.Timer(250); //1000 ms = 1 tick per seconde

            timer.Elapsed += new ElapsedEventHandler((source, e) => Tick()); //Roept Tick aan elke seconde
            timer.AutoReset = true; //de timer wordt constant aangeroepen ipv eenmalig
            
            
        }
        public GameModel game
        {
            get; set;
        }

        public GameView gameView
        {
            get; set;
        }
        public int WaitTicksCount { get; private set; }
        public bool FirstRaise { get; private set; }
        public bool SecondRaise { get; private set; }
        public bool ThirdRaise { get; private set; }

        public GameModel GameModel
        {
            get => default;
            set
            {
            }
        }

        public GameView GameView
        {
            get => default;
            set
            {
            }
        }

        public InputView InputView
        {
            get => default;
            set
            {
            }
        }

        public void Run()
        {
            timer.Enabled = true;
            TickCount = 0;
            _quitGame = false;
            gameView.Show(ParseRailroad());
            InputView input = new InputView();
            FirstRaise = false;
            SecondRaise = false;
            ThirdRaise = false;
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

            TickCount++;
            if(TickCount == WaitTicksCount)
            {
                game.Update();
                if (game.GameOver())
                {
                    Stop();
                    return;
                }
                TickCount = 0;
                if(game.GetScore() > 18 && !FirstRaise)
                {
                    FirstRaise = true;
                    WaitTicksCount = WaitTicksCount--;
                }
                if (game.GetScore() > 25 && !SecondRaise)
                {
                    SecondRaise = true;
                    WaitTicksCount = WaitTicksCount--;
                }
                if (game.GetScore() > 36 && !ThirdRaise)
                {
                    FirstRaise = true;
                    WaitTicksCount = WaitTicksCount--;
                }
            }

            gameView.Update(game.GetShip().ParseShip(), ParseRailroad(), game.GetScore());

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