using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
using Pacman;
using PacManGUI.CollisionFramework;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        GamePacManPlayer pacman;
        List<Ghost> ghost = new List<Ghost>();
        HorizontalGhost HGhost;
        VerticalGhost VGhost;
        RandomGhost RGhost;
        SmartGhost SGhost;
        Label lable = new Label();
        public Form1()
        {
            InitializeComponent();
        }

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateScoreLable(pacman);
            GameGrid grid = new GameGrid("maze.txt", 21, 70);
            Image pacManImage = Game.getGameObjectImage('P');
            Image enemyOrange = Game.getGameObjectImage('O');
            Image enemySmart = Game.getGameObjectImage('B');
            Image enemyWhite = Game.getGameObjectImage('W');
            Image enemyRandom = Game.getGameObjectImage('R');
            GameCell startCell = grid.getCell(3, 33);
            GameCell startRandom = grid.getCell(11, 20);
            GameCell startSmart = grid.getCell(4,4);
            GameCell startVertical = grid.getCell(12, 22);
            GameCell startHorizontal = grid.getCell(13, 20);
            pacman = new GamePacManPlayer(pacManImage, startCell);
            HGhost = new HorizontalGhost(enemyOrange, startHorizontal);
            VGhost = new VerticalGhost(enemyWhite, startVertical);
            RGhost = new RandomGhost(enemyRandom, startRandom);
            SGhost = new SmartGhost(enemySmart, startSmart,pacman);
            ghost.Add(HGhost);
            ghost.Add(VGhost);
            ghost.Add(SGhost);
            ghost.Add(RGhost);

            printMaze(grid);
            CreateScoreLable(pacman);
        }
        private void CreateScoreLable(GamePacManPlayer pacman)
        {

            lable.Top = 20;
            lable.Left = 900;
            lable.ForeColor = Color.White;
            this.Controls.Add(lable);
        }


        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
               
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);          
            //        printCell(cell);
                }

            }
        }
     

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.LeftArrow)) {
             GameCell  playerCell= pacman.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow)){
                pacman.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow)){
                pacman.move(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow)){
                pacman.move(GameDirection.Down);
            }
            for(int i=0;i<ghost.Count;i++)
            {
                ghost[i].Move();
                if (Collision.CheckCollision(pacman, ghost[i]))
                {
                    gameLoop.Enabled = false;
                    this.Hide();
                    ShowGameEnd(PacManGUI.Properties.Resources.pacman_gameover);
                }
            }
            lable.Text = pacman.score.ToString();
        }
        private void ShowGameEnd(Image img)
        {
            gameLoop.Enabled = false;
            FrmGameEnd GameOver = new FrmGameEnd(img);
            DialogResult result = GameOver.ShowDialog();
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            if (result == DialogResult.No)
            {
                Restart();
            }
        }
        private void Restart()
        {
            this.Show();
            this.Controls.Clear();
            Label lable = new Label();
            this.Controls.Add(lable);
            GameGrid grid = new GameGrid("maze.txt", 21, 70);
            Image pacManImage = Game.getGameObjectImage('P');
            Image enemyOrange = Game.getGameObjectImage('O');
            Image enemySmart = Game.getGameObjectImage('B');
            Image enemyWhite = Game.getGameObjectImage('W');
            Image enemyRandom = Game.getGameObjectImage('R');
            GameCell startCell = grid.getCell(3, 33);
            GameCell startRandom = grid.getCell(19, 10);
            GameCell startSmart = grid.getCell(4, 4);
            GameCell startVertical = grid.getCell(12, 22);
            GameCell startHorizontal = grid.getCell(11, 20);
            pacman = new GamePacManPlayer(pacManImage, startCell);
            pacman.score = 0;
            HGhost = new HorizontalGhost(enemyOrange, startHorizontal);
            VGhost = new VerticalGhost(enemyWhite, startVertical);
            RGhost = new RandomGhost(enemyRandom, startRandom);
            SGhost = new SmartGhost(enemySmart, startSmart, pacman);
            ghost.Add(HGhost);
            ghost.Add(VGhost);
            ghost.Add(SGhost);
            ghost.Add(RGhost);
            printMaze(grid);
            gameLoop.Enabled = true;
        }

    }
}
