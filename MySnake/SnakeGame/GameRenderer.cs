using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake.SnakeGame
{
    class GameRenderer
    {
        private PictureBox view;
        private Bitmap wallsBitmap;
        private Bitmap backBufferBitmap;
        private Graphics backBufferGfx;
        private Graphics wallsGfx;
        private int tileWidth = 16;
        private int tileHeight = 16;
        private SnakeGame snakeGame;

        public GameRenderer(PictureBox view, SnakeGame snakeGame)
        {
            this.view = view;
            this.snakeGame = snakeGame;

            OnViewResize();
        }

        private void OnViewResize()
        {
            this.backBufferBitmap = new Bitmap(view.Width, view.Height);
            this.backBufferGfx = Graphics.FromImage(backBufferBitmap);
            this.tileWidth = view.Width / snakeGame.WorldWidth;
            this.tileHeight = view.Height / snakeGame.WorldHeight;
            this.wallsBitmap = new Bitmap(view.Width, view.Height);
            this.wallsGfx = Graphics.FromImage(wallsBitmap);

            RenderWalls();
        }

        private void RenderWalls()
        {
            wallsGfx.Clear(Color.Black);

            Map map = snakeGame.map;
            for (var y = 0; y < snakeGame.WorldHeight; y += 1)
            {
                for (var x = 0; x < snakeGame.WorldWidth; x += 1)
                {
                    if (map.GetTileAt(x, y) == 1)
                    {
                        wallsGfx.FillRectangle(Brushes.LightGray, x * tileWidth,
                           y * tileHeight, tileWidth, tileHeight);
                    }
                }
            }
        }

        public void Render()
        {
            Font font = new Font("Arial", 14);

            // Clear screen
            backBufferGfx.DrawImage(wallsBitmap, 0, 0);

            // Render the snake
            if (snakeGame.GameState == SnakeGame.State.RUNNING)
            {
                Snake snake = snakeGame.Snake;
                CordinatePair head = snake.Head;
                backBufferGfx.FillRectangle(Brushes.Yellow, head.X * tileWidth,
                    head.Y * tileHeight, tileWidth, tileHeight);
                var snakeBits = snake.Tail;
                foreach (CordinatePair snakeBit in snakeBits)
                {
                    backBufferGfx.FillRectangle(Brushes.Yellow, snakeBit.X * tileWidth,
                        snakeBit.Y * tileHeight, tileWidth, tileHeight);
                }

                // Render the apple
                CordinatePair apple = snakeGame.Apple;
                backBufferGfx.FillEllipse(Brushes.Green, apple.X * tileWidth,
                        apple.Y * tileHeight, tileWidth, tileHeight);
            }

            // Draw score
            backBufferGfx.DrawString("SCORE: " + snakeGame.Score, font, Brushes.Black, 2, 2);

            // Draw Game-over string, if we are game over
            if (snakeGame.GameState == SnakeGame.State.GAMEOVER)
            {
                backBufferGfx.DrawString("GAME OVER", font, Brushes.Red, 240, 200);
                backBufferGfx.DrawString("PRESS SPACE TO RESTART", font, Brushes.Red, 170, 260);
            }
            else if (snakeGame.GameState == SnakeGame.State.NOT_STARTED)
            {
                backBufferGfx.DrawString("PRESS SPACE TO START", font, Brushes.Green, 180, 225);
            }


            // Render to screen
            view.Image = backBufferBitmap;
        }
    }
}
