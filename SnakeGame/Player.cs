using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Player
    {
        private int _playerID;
        private Brush _headColor, _bodyColor;

        public int ID { get { return _playerID; } }
        public Brush HeadColor { get { return _headColor; } }
        public Brush BodyColor { get { return _bodyColor; } }

        public int Speed { get; set; }
        public int Score { get; set; }
        public List<Circle> Snake { get;  }
        public Direction direction { get; set; }
        public Player(int playerID, Point startPosition, Brush headColor, Brush bodyColor)
        {
            Speed = 6;
            Score = 0;

            _playerID = --playerID;
            _headColor = headColor;
            _bodyColor = bodyColor;
            direction = GetRandomDirection();

            Snake = new List<Circle>();
            var head = new Circle(startPosition.X, startPosition.Y);
            Snake.Add(head);
        }

        public string ShowScore()
        {
            return string.Format("امتیاز بازیکن شماره {0} , {1} عه", _playerID, Score);
        }
        public void PlayerRestart()
        {
            Snake.Clear();
        }
        private Direction GetRandomDirection()
        {
            return (Direction)new Random().Next(0, 4);
        }
        public void GrowUp(Circle cricle)
        {
            Snake.Add(cricle);
        }
        

    }
}
