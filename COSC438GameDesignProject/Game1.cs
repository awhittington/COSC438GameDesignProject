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
        private GridLayout grid;
        //All statically placed sprites are defined in MapContainer.cs
        private Dictionary<int, Tuple<int, Texture2D, Rectangle>> STATICSPRITES;
        //Point class defines our characters position at all times
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        //MonoStuff
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //Phyics Engine handles all movement, interaction, and collision
        private Physics physicsEngine;
        //MISC Constants. These constants are soley used for dictonary bounds
        private const int MAPSIZE = 240;
        private const int STATICSSIZE = 50;
        private const int STATICOFFSET = 4;
        //sprite Container for map element sprites
        private Dictionary<int, Tuple<int, Texture2D, Rectangle>> spriteContainer;
        //Used for game state interactions and displaying inventory panel
        private Dictionary<int, Tuple<Texture2D>> inventoryContainer;
        //Dynamic sprites
        private Texture2D activePlayer;
        private Texture2D cursorDummy;
        private Texture2D inventory;
        //Coordinates for keyboard and mouse
        private Point currMousePosition;
        private Point currPlayerPosition;
        //Getters & Setters
        public GraphicsDeviceManager graphicsFunc
        {
            get
            {
                return graphics;
            }
        }
        public Texture2D activePlayerFunc
        {
            get
            {
                return activePlayer;
            }
            set
            {
                activePlayer = value;
            }
         }
        public Point currPlayerPositionFunc
        {
            get
            {
                return currPlayerPosition;
            }
        }
        public Point currMousePositionFunc
        {
            get
            {
                return currMousePosition;
            }
        }
        public Texture2D getINV
        {
            get
            {
                return inventory;
            }
        }       
        public Dictionary<int, Tuple<int, Texture2D, Rectangle>> spriteContainerFunc
        {
            get
            {
                return spriteContainer;
            }
            set
            {
                spriteContainer = value;
            }
        }
        public Dictionary<int, Tuple<Texture2D>> inventoryContainerFunc
        {
            get
            {
                return inventoryContainer;
            }
        }
        public Dictionary<int, Tuple<int, Texture2D, Rectangle>> STATICSPRITESFunc
        {
            get
            {
                return STATICSPRITES;
            }
            set
            {
                this.STATICSPRITES = value;
            }
        }
        //Constructor
        public Game1()
        {                       
            //Initialize all data structures (These are essentially Tiles/Grid Boxes). 
            spriteContainer = new Dictionary<int, Tuple<int, Texture2D, Rectangle>>();
            inventoryContainer = new Dictionary<int, Tuple<Texture2D>>();
            STATICSPRITES = new Dictionary<int, Tuple<int, Texture2D, Rectangle>>();
            currPlayerPosition = new Point();
            currMousePosition = new Point();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //TODO: Determine if we should generated levels on initialization or LoadContent
        protected override void Initialize()
        {
            grid = new GridLayout(this);
            grid.generateGrid(1);
            base.Initialize();
        }      
        protected override void LoadContent()
        {
            //////////////////////PRE GAME LOADING
            currPlayerPosition.X = 10;
            currPlayerPosition.Y = graphics.PreferredBackBufferHeight;      
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Generate the initial physicsEngine, this engine processes all movement and collision detection for each map based on the collisionBox for that specificed map
            //NOTE When spawning a new character a new phyicsEngine will likely need to be made(TODETERMINE)
            physicsEngine = new Physics(this,1,spriteBatch, graphics);
            physicsEngine.loadLevel();
            //////////////////////END PRE GAME LOADING
            //Dynamic sprites that are annoying to handle within container element
            inventory = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream(@"Images/Inventory.png"));
            activePlayer = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream(@"Images/P1.png"));
            cursorDummy = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream(@"Images/cursorSprite.png"));
        }
        //TODO Do we need this for our game? :/
        protected override void UnloadContent()
        {
            
        }
        /* TODO
        1.) Implement Level Switching Method
        2.) Implement Character Switching Method
        3.) Implement Collision Detection for all active collision boxes (Within Phyics Class)
        */
        protected override void Update(GameTime gameTime)
        {
         
            //Runs all methods relted to handling user input events.
            //ProcessInputFunctions has a chaining effect to all other detections
            physicsEngine.ProcessInputFunctions(Mouse.GetState(),Keyboard.GetState(),gameTime);
            //Test Player Coordinates Versus Collision boxes.
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            drawActiveSprites();
            drawSprites();
            //Load all static and active sprites
            // drawActiveSprites();
            //Load dynamic sprites
            spriteBatch.Draw(activePlayer, new Rectangle(currPlayerPosition.X, currPlayerPosition.Y - 40, 40, 40), Color.White);
            spriteBatch.Draw(cursorDummy, new Rectangle(currMousePosition.X, currMousePosition.Y, 15, 15), Color.White);
            if (physicsEngine.IDOWNFunc)
            {
               loadInventory();
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void drawSprites()
        {
            foreach (CollisionTile tile in grid.CollisionTile)
            {
               
                spriteBatch.Draw(tile.Image, tile.Box,Color.White);
            }
            foreach (Generic tile in grid.GenericTile)
            {
                spriteBatch.Draw(tile.Image, tile.Box, Color.White);
            }
            foreach (ItemTile tile in grid.ItemTile)
            {
                if (!tile.Collected)
                {
                    spriteBatch.Draw(tile.Image, tile.Box, Color.White);
                }
            }
            foreach (PlatForm tile in grid.PlatFormTile)
            {
                spriteBatch.Draw(tile.Image, tile.Box, Color.White);
            }
        }
        //TODO Get inventory sprite sheet and determine an overlaying method for best results
        public void loadInventory()
        {
            for (int x = 0; x < 10; x++)
            {
                spriteBatch.Draw(inventory, new Rectangle(graphics.PreferredBackBufferWidth - inventory.Width, graphics.PreferredBackBufferHeight - inventory.Height, inventory.Width, inventory.Height), Color.White);
                if (inventoryContainer.ContainsKey(x))
                {
                   // spriteBatch.Draw(inventoryContainer[x].Item1, new Rectangle(graphics.PreferredBackBufferWidth - endImg.Width * 2, graphics.PreferredBackBufferHeight - endImg.Height, inventoryContainer[x].Item1.Width, inventoryContainer[x].Item1.Height), Color.White);
                }
            }
        }
        public void drawActiveSprites()
        {
            for(int y = 0; y < STATICSSIZE; y++)
            {
                if(STATICSPRITES.ContainsKey(y) && STATICSPRITES[y].Item1 == -1)
                {
                    spriteBatch.Draw(STATICSPRITES[y].Item2, STATICSPRITES[y].Item3, Color.White);
                }
                else if (STATICSPRITES.ContainsKey(y))
                {
                    
                }
            }
            spriteBatch.Draw(STATICSPRITES[physicsEngine.ACTIVELEVELFunc + STATICOFFSET].Item2, STATICSPRITES[physicsEngine.ACTIVELEVELFunc + STATICOFFSET].Item3, Color.White);
        }
        //Check the sprite to be loaded versus inventory
        //TODO:: STOP Inventory item's from being recreated on level transitions
        public bool checkInventory(Texture2D item)
        {
            for(int y = 0; y < spriteContainer.Count; y++)
            {
                if (inventoryContainer.ContainsKey(y))
                {
                    if (item.Equals(inventoryContainer[y].Item1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }  
          
    }
}
