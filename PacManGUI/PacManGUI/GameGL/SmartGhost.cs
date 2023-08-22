using PacManGUI.CollisionFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class SmartGhost : Ghost
    {
       // GameDirection Direction;
        GamePacManPlayer player;
        public SmartGhost(Image G, GameCell start, GamePacManPlayer targetplayer) : base(G, start)
        {
            player = targetplayer;
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
            GameCell nextCell = FindNextCell(currentCell, player);
            if (Collision.CheckReward(nextCell))
            {
                PreviousObject = GameObjectType.REWARD;
            }
            else if (Collision.CheckBlank(nextCell))
            {
                PreviousObject = GameObjectType.NONE;
            }
            this.CurrentCell = nextCell;
            
            return nextCell;
        }

        private GameCell FindNextCell(GameCell currentCell, GamePacManPlayer playerCell)
        {
            List<GameCell> availableCells = GetAvailableCells(currentCell);

            GameCell closestCell = null;
            double closestDistance = double.MaxValue;

            foreach (GameCell cell in availableCells)
            {
                double distance = CalculateDistance(cell, playerCell);
                if (distance < closestDistance)
                {
                    closestCell = cell;
                    closestDistance = distance;
                }
            }

            return closestCell;
        }

        private List<GameCell> GetAvailableCells(GameCell currentCell)
        {
            List<GameCell> availableCells = new List<GameCell>();

            foreach (GameDirection direction in Enum.GetValues(typeof(GameDirection)))
            {
                GameCell nextCell = currentCell.nextCell(direction);
                if (nextCell != null)
                {
                    availableCells.Add(nextCell);
                }
            }

            return availableCells;
        }

        private double CalculateDistance(GameCell cell1, GamePacManPlayer cell2)
        {
            int xDiff = Math.Abs(cell1.X - cell2.CurrentCell. X);
            int yDiff = Math.Abs(cell1.Y - cell2.CurrentCell. Y);
            double distance =Math.Sqrt( xDiff*2 + yDiff*2);

            return distance;
        }
    }
}
