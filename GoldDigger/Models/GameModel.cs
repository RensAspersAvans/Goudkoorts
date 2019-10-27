using GoldDigger.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoldDigger
{
    public class GameModel
    {
        private int _score;
        private bool _gameOver;
        private Ship ship;
        public RailRoadModel rm { get; set; }
        public int DifficultyTickLevel;
        public int Difficulty
        {
            get { return rm.difficulty; }
            set { rm.difficulty = value;  }
        }


        public GameModel()
        {
            _score = 0;
            _gameOver = false;
            this.ship = new Ship();
            this.rm = new RailRoadModel();
            this.rm.shipBoard.ship = ship;
        }
        

        public Track[] GetLayers()
        {
            return rm.Layers;
        }

        public void addScore(int score)
        {
            _score += score;
        }

        public int GetScore()
        {
            return _score;
        }

        public bool GameOver()
        {
            return _gameOver;
        }

        public void Update()
        {
            
            if (!rm.MoveCarts())
            {
                _gameOver = true;
                return;
            }
            
            rm.AddCart();

            DifficultyTickLevel++;

            if (DifficultyTickLevel == 10)
            {
                if (Difficulty != 10)
                {
                    DifficultyTickLevel = 0;
                    Debug.WriteLine("Its getting harder");
                }
            }
            ship.Update();
        }

        public Ship GetShip()
        {
            return ship;
        }
    }
}