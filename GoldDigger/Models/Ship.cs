﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger.Models
{
    public class Ship
    {
        private int _load;
        private bool _isReady = false; //true = staat klaar om een lading te ontvangen, false = is nog niet verschenen
        
        private GameModel game { get; set; }

        Random _rnd = new Random();

        public void Update()
        {
            if(!_isReady)
            {                
                int chance = _rnd.Next(1, 10);  // pakt een willekeurig nummer tussen 1 en 9
                if(chance >= 6)
                {
                    _isReady = true;                    
                }
            }
            else
            {
                if(_load == 8)
                {
                    game.addScore(10);
                    _load = 0;
                    _isReady = false;
                }
            }
        }

        public void addLoad()
        {
            _load++;
            game.addScore(1);
        }

        public bool IsReady()
        {
            return _isReady;
        }

       public String ParseShip()
        {
            if(!_isReady)
            {
                return "";
            }
            else
            {
                String _shipString = "|";
                for (int i = 0; i < 8; i++)
                {
                    if (_load > i)
                    {
                        _shipString += "*";
                    }
                    else
                    {
                        _shipString += " ";
                    }
                }
                _shipString += "|";
                return _shipString + _load;
                //voorbeeld: |******  |
            }


        }

    }
}
