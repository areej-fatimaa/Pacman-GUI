using PacMan.GameGL;
using PacManGUI.CollisionFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class VerticalGhost : Ghost
    {
       // GameDirection Direction;
        public VerticalGhost(Image G, GameCell start) : base(G, start)
        {
            Direction = GameDirection.Up;
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
            if (currentCell == nextCell && Direction == GameDirection.Up)
            {
                Direction = GameDirection.Down;
            }
            else if (currentCell == nextCell && Direction == GameDirection.Down)
            {
                Direction = GameDirection.Up;
            }
            return nextCell;
        }
    }
}
