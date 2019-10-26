using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class GameModel
    {
        private int _score;
        private bool _gameOver;
        private RailRoadModel rm;


        public GameModel()
        {
            _score = 0;
            _gameOver = false;
        }
        public RailRoadModel RailRoadModel
        {
            get => default;
            set
            {
            }
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
        }
    }
}