using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopProject.Design_Patterns.StrategyPattern.ConcreteStartegies;
using ShopProject.Design_Patterns.StrategyPattern.StrategyBase;
using ShopProject.Design_Patterns.StrategyPattern;
using System.Diagnostics;
using ShopProject.Design_Patterns.BuilderPattern.Director;
using ShopProject.Design_Patterns.BuilderPattern.Product;
using ShopProject.Design_Patterns.BuilderPattern.ConcreteBuilder;
using ShopProject.Design_Patterns.BuilderPattern.Builder;
using ShopProject.Design_Patterns.SingletonPattern;

namespace ShopProject.Game
{
    public partial class BrickBreaker : Form
    {
        Player p;
        
        int BallX = 8, BallY = 70, numberofremovedbricks = 0;
        bool IsGameOver, level2 = false;
        Random rnd = new Random();

        PictureBox[] BlockArray;
        PictureBox Ball;
        Score ScoreValue;
        int totalnumberofbricks = 15, maxballtop = 400, minballtop = 0, minballleft = 0, maxballright = 400;
         
        public BrickBreaker()
        {
            InitializeComponent();
            StartTheGame();
        }

        public void StartTheGame()
        {
            createPlayer();
            CreateBall();
            PlaceBlocks();
            SetupTheGame();
            BrickBreakerTimer.Start();
        }

        public void createPlayer()
        {
            p = new Player();
            this.Controls.Add(p._player);
        }

        public void CreateBall()
        {
            var blockcreator = new BlockCreator(new BallBuilder());
            blockcreator.CreateBlock(0);
            var b = blockcreator.GetBlock();
            Ball = b.block;
            this.Controls.Add(Ball);
        }

        private void PlaceBlocks()
        {
            BlockArray = new PictureBox[totalnumberofbricks];
            for (int i = 0; i < BlockArray.Length; i++)
            {
                if (!level2)
                {
                    var blockcreator = new BlockCreator(new LargeBlocksBuilder());
                    blockcreator.CreateBlock(i);
                    var b = blockcreator.GetBlock();
                    BlockArray[i] = b.block;
                    this.Controls.Add(BlockArray[i]);
                }
                else
                {
                    var blockcreator = new BlockCreator(new SmallBlocksBuilder());
                    blockcreator.CreateBlock(i);
                    var b = blockcreator.GetBlock();
                    BlockArray[i] = b.block;
                    this.Controls.Add(BlockArray[i]);
                }
            }
        }

        private void SetupTheGame()
        {
            ScoreValue = Score.GetScore();
            createScoreLabel();
            IsGameOver = false;
            ScoreLabel.Text = "Score = " + ScoreValue.ScoreCount;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }

        public void createScoreLabel()
        {
            ScoreLabel = ScoreValue.scorelabel;
            this.Controls.Add(ScoreLabel);
        }

        private void BrickBreakerTimer_Tick(object sender, EventArgs e)
        {
            if (!level2) p.Move();
            else p.MoveSlower();
            ballCode();
            scoreCode();
        }
        
        void ballCode()
        {
            Ball.Left += BallX;
            Ball.Top += BallY;

            if (Ball.Left < minballleft || Ball.Left > maxballright) BallX = -BallX;
            if (Ball.Top < minballtop) BallY = -BallY;

            if (Ball.Bounds.IntersectsWith(p._player.Bounds))
            {
                BallY = rnd.Next(5, 12) * -1;
                if (BallX < 0) BallX = rnd.Next(5, 12) * -1;
                else BallX = rnd.Next(5, 12);
            }

            foreach (Control x in this.Controls)
            {
                if ((x is PictureBox && (string)x.Tag == "Blocks") && Ball.Bounds.IntersectsWith(x.Bounds))
                {
                    numberofremovedbricks++;
                    ScoreValue.ScoreCount += 1;
                    BallY = -BallY;
                    this.Controls.Remove(x);
                }
            }
        }

        void scoreCode()
        {
            ScoreLabel.Text = "Score = " + ScoreValue.ScoreCount;

            if (numberofremovedbricks == totalnumberofbricks)
            {
                numberofremovedbricks = 0;
                GameOver("You Won, Press enter to play again");
                level2 = true;
            }
            if (Ball.Top > maxballtop)
            {
                GameOver("You Lost, Press enter to play again");
                numberofremovedbricks = 0;
                ScoreValue.ScoreCount = 0;
                level2 = false;
            }
            
        }

        private void GameOver(string message)
        {
            IsGameOver = true;
            BrickBreakerTimer.Stop();
            MessageBox.Show(message);
        }

        private void RemoveBlocks()
        {
            foreach (PictureBox x in BlockArray)
            {
                this.Controls.Remove(x);
            }
        }
        
        private void BrickBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) p.behaviour = new GoLeftBehavior();
            if (e.KeyCode == Keys.Right) p.behaviour = new GoRightBehaviour();
            if (e.KeyCode == Keys.Up) p.behaviour = new GoUpBehaviour();
            if (e.KeyCode == Keys.Down) p.behaviour = new GoDownBehaviour();
        }

        private void BrickBreaker_KeyUp(object sender, KeyEventArgs e)
        {
            if (p.behaviour.GetType() == typeof(GoLeftBehavior) && e.KeyCode == Keys.Left) p.behaviour = new InitialBehaviour();
            if (p.behaviour.GetType() == typeof(GoRightBehaviour) && e.KeyCode == Keys.Right) p.behaviour = new InitialBehaviour();
            if (p.behaviour.GetType() == typeof(GoUpBehaviour) && e.KeyCode == Keys.Up) p.behaviour = new InitialBehaviour();
            if (p.behaviour.GetType() == typeof(GoDownBehaviour) && e.KeyCode == Keys.Down) p.behaviour = new InitialBehaviour();

            if (e.KeyCode == Keys.Enter && IsGameOver == true)
            {
                p.behaviour = new InitialBehaviour();
                RemoveBlocks();
                this.Controls.Remove(p._player);
                this.Controls.Remove(Ball);
                StartTheGame();
            }
        }
        
        private void BrickBreaker_Load(object sender, EventArgs e)
        { }

        /*
        bool GoLeft, GoRight, IsGameOver;
        int BallX = 8, BallY = 50, Score = 0, PlayerSpeed = 12;
        Random rnd = new Random();

        PictureBox[] BlockArray;

        public BrickBreaker()
        {
            InitializeComponent();
            PlaceBlocks();
        }

        private void BrickBreakerTimer_Tick(object sender, EventArgs e)
        {
            ScoreLabel.Text = "Score = " + Score;
            if (GoLeft == true && Player.Left > 0) Player.Left -= PlayerSpeed;
            if (GoRight == true && Player.Left < 330) Player.Left += PlayerSpeed;

            Ball.Left += BallX;
            Ball.Top += BallY;

            if (Ball.Left < 0 || Ball.Left > 400) BallX = -BallX;
            if (Ball.Top < 0) BallY = -BallY;

            if (Ball.Bounds.IntersectsWith(Player.Bounds))
            {
                BallY = rnd.Next(5, 12) * -1;
                if (BallX < 0) BallX = rnd.Next(5, 12) * -1;
                else BallX = rnd.Next(5, 12);
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Blocks")
                {
                    if (Ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Score += 1;
                        BallY = -BallY;
                        this.Controls.Remove(x);
                    }
                }
            }
            if (Score == 15) GameOver("You Won, Press enter to play again");
            if (Ball.Top > 400) GameOver("You Lost, Press enter to play again");
        }

        private void PlaceBlocks()
        {
            BlockArray = new PictureBox[15];
            int a = 0, Top = 50, Left = 50;

            for (int i = 0; i < BlockArray.Length; i++)
            {
                
                BlockArray[i] = new PictureBox();
                BlockArray[i].Height = 16;
                BlockArray[i].Width = 50;
                BlockArray[i].Tag = "Blocks";
                BlockArray[i].BackColor = Color.White;
                a++;
                BlockArray[i].Left = Left;
                BlockArray[i].Top = Top;
                this.Controls.Add(BlockArray[i]);
                Left = Left + 70;
                if (a == 5)
                {
                    Top = Top + 50;
                    Left = 50;
                    a = 0;
                }
                
            }
            SetupTheGame();
        }

        private void SetupTheGame()
        {
            Score = 0;
            IsGameOver = false;
            Ball.Left = 250;
            Ball.Top = 300;
            Player.Left = 200;
            Player.Top = 350;
            ScoreLabel.Text = "Score = " + Score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
            BrickBreakerTimer.Start();
        }

        private void GameOver(string message)
        {
            IsGameOver = true;
            BrickBreakerTimer.Stop();
            ScoreLabel.Text = "Score = " + Score + " " + message;
        }

        private void RemoveBlocks()
        {
            foreach (PictureBox x in BlockArray)
            {
                this.Controls.Remove(x);
            }
        }

        private void BrickBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) GoLeft = true;
            if (e.KeyCode == Keys.Right) GoRight = true;
            if (e.KeyCode == Keys.Up) PlayerSpeed++;
            if (e.KeyCode == Keys.Down) PlayerSpeed--;
            if (e.KeyCode == Keys.Q) BallY++;
            if (e.KeyCode == Keys.W) BallY--;
        }

        private void BrickBreaker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) GoLeft = false;
            if (e.KeyCode == Keys.Right) GoRight = false;

            if (e.KeyCode == Keys.Enter && IsGameOver == true)
            {
                RemoveBlocks();
                PlaceBlocks();
            }
        }

        private void BrickBreaker_Load(object sender, EventArgs e)
        {

        }
        */
    }
}