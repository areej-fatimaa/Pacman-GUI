using PacManGUI.CollisionFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class RandomGhost : Ghost
    {
     
        Random rand = new Random();
        public RandomGhost(Image G, GameCell start) : base(G, start)
        {
            Direction = GameDirection.Up;
        }
        public GameDirection ghostDirection()
        {
            GameDirection direction=GameDirection.Left;
            int x=rand.Next(0, 4);
            if(x==1)
            {
                direction = GameDirection.Down;

            }
            if (x == 2)
            {
                direction = GameDirection.Up;

            }
            if (x == 3)
            {
                direction = GameDirection.Right;

            }
            return direction;
        }
        public override GameCell Move()
        {

            if (PreviousObject == GameObjectType.REWARD)
            {
                CurrentCell.setGameObject(Game.getRewardGameObject());
            }
            if (PreviousObject == GameObjectType.NONE)
            {
                CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            GameCell currentCell = this.CurrentCell;
            Direction = ghostDirection();
            GameCell nextCell = currentCell.nextCell(Direction);
            if (Collision.CheckReward(nextCell))
            {
                PreviousObject = GameObjectType.REWARD;
            }
            else if (Collision.CheckBlank(nextCell))
            {
                PreviousObject = GameObjectType.NONE;
            }
            this.CurrentCell = nextCell;
            /*if (currentCell != nextCell)
            {
                CurrentCell.setGameObject(Game.getBlankGameObject());
            }*/ 
           
            return nextCell;

            //    Random rand = ghostDirection();

            //if (PreviousObject == GameObjectType.NONE)
            //{
            //    CurrentCell.setGameObject(Game.getBlankGameObject());
            //}
            //if (PreviousObject == GameObjectType.REWARD)
            //{
            //    CurrentCell.setGameObject(Game.getRewardGameObject());
            //}
            //GameCell currentCell = this.CurrentCell;
            //    GameCell nextCell = currentCell.nextCell(Direction);

            //if (Collision.CheckBlank(nextCell))
            //{
            //    PreviousObject = GameObjectType.NONE;
            //}
            //if (Collision.CheckReward(nextCell))
            //{
            //    PreviousObject = GameObjectType.REWARD;
            //}
            //this.CurrentCell = nextCell;
            //if (currentCell != nextCell)
            //{
            //    if (PreviousObject == GameObjectType.NONE)
            //    {
            //        currentCell.setGameObject(Game.getBlankGameObject());
            //    }
            //    if (PreviousObject == GameObjectType.REWARD)
            //    {
            //        CurrentCell.setGameObject(Game.getRewardGameObject());
            //    }
            //}
            //else
            //{
            //    currentCell.X = rand.Next(1, 20);
            //    currentCell.Y=rand.Next(1, 60);
            //}
            //return nextCell;
        }
    }
}
