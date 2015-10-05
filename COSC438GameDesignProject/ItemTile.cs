using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COSC438GameDesignProject
{
    public class ItemTile : Tile
    {
        private bool collected = false;
        public ItemTile(int key, Rectangle newBox, Game1 game)
            : base(game)
        {
            this.image = Texture2D.FromStream(game.GraphicsDevice, TitleContainer.OpenStream(@"Images/I1.png"));
            this.Box = newBox;
        }
        public bool Collected
        {
            get
            {
                return collected;
            }
            set
            {
                collected = value;
            }
        }
    }
}
