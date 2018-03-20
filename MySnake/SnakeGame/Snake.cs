using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.SnakeGame
{
    public class Snake
    {
        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        public CordinatePair Head { get; set; }
        public List<CordinatePair> Tail { get; set; }
        private Direction direction;
        private int numberOfTailElements = 0;

        public Snake(int x, int y)
        {
            direction = Direction.RIGHT;
            Tail = new List<CordinatePair>();
            Head = new CordinatePair { X = x, Y = y};
        }

        public void GrowBigger()
        {
            CordinatePair lastSnakeBit = numberOfTailElements != 0 ? Tail.Last() : Head;

            CordinatePair snakeBit = new CordinatePair
            { X = lastSnakeBit.X, Y = lastSnakeBit.Y };
            Tail.Add(snakeBit);

            numberOfTailElements += 1;
        }

        internal void TryChangeDirection(Direction newDirection)
        {
            switch (newDirection)
            {
                case Direction.LEFT:
                    if (numberOfTailElements > 0 && Tail[0].Y == Head.Y && Tail[0].X == Head.X - 1)
                    {
                        return;
                    }
                    break;
                case Direction.RIGHT:
                    if (numberOfTailElements > 0 && Tail[0].Y == Head.Y && Tail[0].X == Head.X + 1)
                    {
                        return;
                    }
                    break;
                case Direction.UP:
                    if (numberOfTailElements > 0 && Tail[0].Y == Head.Y - 1 && Tail[0].X == Head.X)
                    {
                        return;
                    }
                    break;
                case Direction.DOWN:
                    if (numberOfTailElements > 0 && Tail[0].Y == Head.Y + 1 && Tail[0].X == Head.X)
                    {
                        return;
                    }
                    break;
            }

            this.direction = newDirection;
        }

        public void Update()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    Move(-1, 0);
                    break;
                case Direction.RIGHT:
                    Move(1, 0);
                    break;
                case Direction.UP:
                    Move(0, -1);
                    break;
                case Direction.DOWN:
                    Move(0, 1);
                    break;
            }
        }

        private void Move(int x, int y)
        {
            for (var i = numberOfTailElements - 1; i > -1; i -= 1)
            {
                CordinatePair tailElement = Tail[i];
                CordinatePair leadingTail = i == 0 ? Head : Tail[i - 1];

                tailElement.X = leadingTail.X;
                tailElement.Y = leadingTail.Y;
               // tailElement.Movable = true;
            }

            Head.X += x;
            Head.Y += y;
        }
    }
}
