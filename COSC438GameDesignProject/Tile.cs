using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Class Layout from tutorial
//https://www.youtube.com/watch?v=PKlHcxFAEk0&list=PL667AC2BF84D85779&index=42

namespace COSC438GameDesignProject
{
    public class Tile
    {
        protected Game1 game;
        protected Texture2D image;

        private Rectangle box;
        public Tile(Game1 game)
        {
            this.game = game;
        }
        public Rectangle Box
        {
            get
            {
                return box;
            }
            set
            {
                box = value;
            }
        }
        
        public Texture2D Image
        {
            get
            {
                return image;
            }
        }
       
    }
    class CollisionTile : Tile
    {
        public CollisionTile(int key, Rectangle newBox, Game1 game) : base(game)
        {
            this.image = Texture2D.FromStream(game.GraphicsDevice, TitleContainer.OpenStream(@"Images/B.png"));
            this.Box = newBox;
        }
    }
    class ItemTile : Tile
    {
        private bool collected = false;
        public ItemTile(int key, Rectangle newBox,Game1 game) : base(game)
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
    class Generic : Tile
    {
        public Generic(int key, Rectangle newBox, Game1 game) : base(game)
        {
            this.image = Texture2D.FromStream(game.GraphicsDevice, TitleContainer.OpenStream(@"Images/background.jpg"));
            this.Box = newBox;
        }
    }
    class PlatForm : Tile
    {
        public PlatForm(int key, Rectangle newBox, Game1 game) : base(game)
        {
            this.image = Texture2D.FromStream(game.GraphicsDevice, TitleContainer.OpenStream(@"Images/PlatForm.png"));
            this.Box = newBox;
        }
    }
}

