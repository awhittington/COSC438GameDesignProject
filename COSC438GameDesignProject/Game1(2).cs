using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace COSC438GameDesignProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Physics physicsEngine;
        GridLayout genMaps;
        const int MAPSIZE = 240;
        //sprite Container for generic map elements (Elements that are in fixed positions and only change due to state changes)
        Dictionary<int, Tuple<int, Texture2D, Rectangle>> spriteContainer;
        //Easily determined/Dynamic sprites
        private Texture2D activePlayer;
        private Texture2D lvl1Header;
        private Texture2D cursorDummy;
        private Texture2D backgroundImg;
        private Texture2D rocks;
        private Texture2D caveTop;
        private Texture2D endImg;
        private Texture2D inventory;
        //Coordinates
        private int mouseX;
        private int mouseY;
        private int playerXPOS;
        private int playerYPOS;
        //Getters & Setters
        public Texture2D getINV
        {
            get
            {
                return inventory;
            }
        }
        public int mouseXFunc
        {
            get
            {
                return mouseX;
            }
            set
            {
                this.mouseX = value;
            }
        }
        public int mouseYFunc
        {
            get
            {
                return mouseY;
            }
            set
            {
                this.mouseY = value;
            }
        }
        public int playerXPOSFunc
        {
            get
            {
                return playerXPOS;
            }
            set
            {
                this.playerXPOS = value;
            }
        }
        public int playerYPOSFunc
        {
            get
            {
                return playerYPOS;
            }
            set
            {
                this.playerYPOS = value;
            }
        }
        public Dictionary<int, Tuple<int, Texture2D, Rectangle>> spriteContainerFunc
        {
            get
            {
                return spriteContainer;
            }
        }

        //Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //TODO: Determine if we should generated levels on initialization or LoadContent
        protected override void Initialize()
        {
            base.Initialize();
        }      
        protected override void LoadContent()
        {
            //////////////////////PRE GAME LOADING
            playerXPOS = 0;
            playerYPOS = graphics.PreferredBackBufferHeight;
            //This construction generates the collision boxes for lvl1.
            genMaps = new GridLayout(this);
            //Generate Grid for Level One
            genMaps.generateGrid(1);
            //Generate the initial physicsEngine, this engine processes all movement and collision detection for each map based on the collisionBox for that specificed map
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //NOTE When spawning a new character a new phyicsEngine will likely need to be made(TODETERMINE)
            physicsEngine = new Physics(this, playerXPOS, playerYPOS, 1, spriteBatch, graphics);
            //////////////////////END PRE GAME LOADING
            lvl1Header = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream(@"Images/LvL1.png"));
            activePlayer = this.Content.Load<Texture2D>("p1Placeholder");
            inventory = this.Content.Load<Texture2D>("Inventory");
            cursorDummy = this.Content.Load<Texture2D>("cursorSprite");
            backgroundImg = this.Content.Load<Texture2D>("background");
            rocks = this.Content.Load<Texture2D>("Rocks");
            endImg = this.Content.Load<Texture2D>("End");
            caveTop = this.Content.Load<Texture2D>("CaveTop");
            // TODO: use this.Content to load your game content here
        }
        //TODO Do we need this for our game? :/
        protected override void UnloadContent()
        {
            Content.Unload();
            // TODO: Unload any non ContentManager content here
        }
        /* TODO
        1.) Implement Level Switching Method
        2.) Implement Character Switching Method
        3.) Implement Collision Detection for all active collision boxes (Within Phyics Class)
        */
        protected override void Update(GameTime gameTime)
        {
            //Runs all methods relted to handling user input events
            physicsEngine.ProcessInputFunctions(Mouse.GetState(),Keyboard.GetState());
            physicsEngine.ItemDetection();
            //Test Player Coordinates Versus Collision boxes.
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteContainer = genMaps.spriteContainerGetter();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();          
            //Load the Design layout sprites
            spriteBatch.Draw(backgroundImg, new Rectangle(0, 0, backgroundImg.Width, backgroundImg.Height), Color.White);
            spriteBatch.Draw(lvl1Header, new Rectangle(graphics.PreferredBackBufferWidth / 2 - (lvl1Header.Width / 2), caveTop.Height, lvl1Header.Width, lvl1Header.Height), Color.White);
            spriteBatch.Draw(caveTop, new Rectangle(0, 0, caveTop.Width, caveTop.Height), Color.White);
            spriteBatch.Draw(endImg, new Rectangle(graphics.PreferredBackBufferWidth - endImg.Width, graphics.PreferredBackBufferHeight - endImg.Height, endImg.Width, endImg.Height), Color.White);
            spriteBatch.Draw(rocks, new Rectangle(0, graphics.PreferredBackBufferHeight - rocks.Height, rocks.Width, rocks.Height), Color.White);
            spriteBatch.Draw(activePlayer, new Rectangle(playerXPOS, playerYPOS - 40, 40, 40), Color.White);
            spriteBatch.Draw(cursorDummy, new Rectangle(mouseX, mouseY, 15, 15), Color.White);
            //Based on Map Information this function loads the Statically placed sprites.
            drawActiveSprites();           
            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
        public void drawActiveSprites()
        {
            for (int x = 0; x < MAPSIZE; x++)
            {
                if (spriteContainer.ContainsKey(x))
                { 
                    spriteBatch.Draw(spriteContainer[x].Item2, spriteContainer[x].Item3, Color.White);
                }      
            }
        }
    }
}
