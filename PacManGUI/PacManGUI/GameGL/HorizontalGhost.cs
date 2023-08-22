using PacManGUI.CollisionFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class HorizontalGhost:Ghost
    {
        public HorizontalGhost(Image G, GameCell start) : base(G,start)
        {
            Direction =GameDirection.Right;
        }
        public override GameCell Move()
        {
            if(PreviousObject==GameObjectType.REWARD)
            {
                CurrentCell.setGameObject(Game.getRewardGameObject());
            }
            if (PreviousObject == GameObjectType.NONE)
            {
                CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(Direction);
            if(Collision.CheckReward(nextCell))
            {
                PreviousObject = GameObjectType.REWARD;
            }
            else if (Collision.CheckBlank(nextCell))
            {
                PreviousObject = GameObjectType.NONE;
            }
            this.CurrentCell = nextCell;
            if (currentCell == nextCell && Direction == GameDirection.Right)
            {
                Direction = GameDirection.Left;
            }
            else if (currentCell == nextCell && Direction == GameDirection.Left)
            {
                Direction = GameDirection.Right;
            }
            
            return nextCell;
            }
    }
}
