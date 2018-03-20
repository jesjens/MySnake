using MySnake.SnakeGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake
{
    public partial class Form1 : Form
    {
        SnakeGame.SnakeGame snakeGame;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    snakeGame.KeyLeftPressed();
                    break;
                case Keys.Right:
                    snakeGame.KeyRightPressed();
                    break;
                case Keys.Up:
                    snakeGame.KeyUpPressed();
                    break;
                case Keys.Down:
                    snakeGame.KeyDownPressed();
                    break;
                case Keys.Space:
                    snakeGame.StartNewGame();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            snakeGame = new SnakeGame.SnakeGame(view);
            this.PreviewKeyDown += Form1_PreviewKeyDown;
            this.KeyPreview = true;
        }

        private void view_Click(object sender, EventArgs e)
        {

        }
    }
}
