using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger
{
    public class GameModel
    {
        private int _score;
        private bool _gameOver;


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
            
        }
    }
}