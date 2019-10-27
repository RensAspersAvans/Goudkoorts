using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class GameModel
    {
        private int _score;
        private bool _gameOver;
        private RailRoadModel rm { get; set; }


        public GameModel()
        {
            _score = 0;
            _gameOver = false;
            this.rm = new RailRoadModel();
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
            rm.AddCart();
            if (!rm.MoveCarts())
            {
                _gameOver = true;
                return;
            }
        }
    }
}