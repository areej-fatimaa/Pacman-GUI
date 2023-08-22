  using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacMan.GameGL
{
   abstract class Ghost:GameObject
    {
        protected GameDirection Direction;
        public GameObjectType PreviousObject = GameObjectType.NONE;
        public Ghost(Image enemy, GameCell start) : base(GameObjectType.ENEMY, enemy)
        {
            this.CurrentCell = start;
        }
         public abstract GameCell Move();

    }
}
