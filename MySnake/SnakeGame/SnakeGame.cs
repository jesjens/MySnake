using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;

namespace MySnake.SnakeGame
{
    class SnakeGame
    {
        public enum State
        {
            NOT_STARTED,
            RUNNING,
            GAMEOVER
        }

        private Random rnd = new Random();
      
        public State GameState { get; set; }    
        public Map map { get; set; }
        public int Score { get; set; }
        public Snake Snake { get; set; }
        public int WorldWidth { get; set; } = 20;
        public int WorldHeight { get; set; } = 20;
        public CordinatePair Apple { get; set; }

        GameRenderer gameRenderer;
        System.Timers.Timer timer;

        public SnakeGame(PictureBox pictureBox)
        {
            map = new Map();
            Apple = new CordinatePair();
            gameRenderer = new GameRenderer(pictureBox, this);
            InitNewSnake();
            InitApple();

            GameState = State.NOT_STARTED;
            timer = new System.Timers.Timer(120);
            timer.Elapsed += new ElapsedEventHandler(Update);
            timer.Start();
        }

        public void InitNewSnake()
        {
            Snake = new Snake(9, 9);
        }

        public void StartNewGame()
        {
            if (GameState != State.RUNNING)
            {
                InitNewSnake();
                InitApple();
                Score = 0;

                GameState = State.RUNNING;
            }
        }

        private void InitApple()
        {
            Apple.X = rnd.Next(2, WorldWidth - 2);
            Apple.Y = rnd.Next(2, WorldHeight - 2);
        }

        internal void KeyLeftPressed()
        {
            Snake.TryChangeDirection(Snake.Direction.LEFT);
        }

        internal void KeyRightPressed()
        {
            Snake.TryChangeDirection(Snake.Direction.RIGHT);
        }

        internal void KeyUpPressed()
        {
            Snake.TryChangeDirection(Snake.Direction.UP);
        }

        internal void KeyDownPressed()
        {
            Snake.TryChangeDirection(Snake.Direction.DOWN);
        }

        public void Update(object source, ElapsedEventArgs e)
        {
            if (GameState == State.RUNNING)
            {
                // Check collison between snake and apple
                CordinatePair snakeHead = Snake.Head;
                if (snakeHead.X == Apple.X && snakeHead.Y == Apple.Y)
                {
                    Score += 1;
                    InitApple();

                    Snake.GrowBigger();
                }

                Snake.Update();

                // Check collision between head and tail
                List<CordinatePair> tail = Snake.Tail;
                foreach (CordinatePair snakeBit in tail)
                {
                    if (snakeHead.X == snakeBit.X && snakeHead.Y == snakeBit.Y)
                    {
                        GameOver();
                    }
                }

                // Check collision between snake and walls
                if (map.GetTileAt(Snake.Head.X, Snake.Head.Y) == 1)
                {
                    GameOver();
                }
            }
            Render();
        }

        private void GameOver()
        {
            GameState = State.GAMEOVER;
        }

        public void Render()
        {
            gameRenderer.Render();
        }
    }
}
