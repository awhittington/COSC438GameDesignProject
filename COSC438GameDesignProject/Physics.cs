using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;
/*RESOURCES USED:::::::::::::::::::::::::::::::::::::::::::
http://www.xnadevelopment.com/tutorials/thewizardjumping/thewizardjumping.shtml
:::::::::::::::::::::::::::::::::::::::::::::::::::::::::*/
/*
    As of 10/3/2015
    TODO::
    1.)Fix many bugs
        -Collision Bugs, Character Stuck in some movements, character not properly stopping on some bounding box positions.
        -Before generating the spriteContainer check values against those contained in the inventory to eliminate multiple spawning items.
    2.)Implementations
        -Implement Character Sprite Switching functionality even if gameplay doesnt quite dictate it yet.
*/
namespace COSC438GameDesignProject
{
    class Physics 
    {
        private bool jumpState = false;
        //TWO Constants assume a 20x12 grid and a 40Pixel Character Width
        private const int MAPSIZE = 240;
        private const int ZONEOFFSET = 52;
        //Useful Primitives
        private int characterNum;
        private bool IDOWN = false;
        private int ACTIVELEVEL;
        //MonoStuff & Objects
        private Game1 gameObj;
        private GridLayout genMaps;
        private MouseState checkMouseState;
        private KeyboardState checKeyBoardState;
        private SpriteBatch sprites;
        private GraphicsDeviceManager graphics;
        private Vector2 velocity;
        //Getters/Setters
        public int ACTIVELEVELFunc
        {
            get
            {
                return ACTIVELEVEL;
            }
            set
            {
                ACTIVELEVEL = value;
            }

        }
        public bool IDOWNFunc
        {
            get
            {
                return IDOWN;
            }
        }
        //TODO Determine all parameters needed to spawn a physics class with functionality.
        public Physics(Game1 gameObj, int characterNum, SpriteBatch sprites, GraphicsDeviceManager graphics)
        {          
            ACTIVELEVEL = 1;
            this.gameObj = gameObj;
            this.characterNum = characterNum;
            this.sprites = sprites;
            this.graphics = graphics;
        }
        //Chaining method for most phyics processing
        public void ProcessInputFunctions(MouseState mouseState, KeyboardState keyBoardState,GameTime gameTime)
        {
            //capture mouse state
            this.checkMouseState = mouseState;
            //Process mouse state
            CheckMouseInput(checkMouseState);
            //Capture the keyboard state
            this.checKeyBoardState = keyBoardState;
            //Process keyboard state
            CheckKeyBoardInput(checKeyBoardState,gameTime);
            gameObj.currPlayerPositionFunc.Y += (int)velocity.Y;
            gameObj.currPlayerPositionFunc.X += (int)velocity.X;
        }
        //Load new map using map matrix/grid
        public void loadLevel()
        {           
            //Update characters starting position
            gameObj.currPlayerPositionFunc.X = 12;
            gameObj.currPlayerPositionFunc.Y = graphics.PreferredBackBufferHeight;
            velocity.X = 0;
            velocity.Y = 0;
            jumpState = false;
            genMaps = gameObj.Grid;
            //Load relevant level
            switch (ACTIVELEVEL)
            {
                case 0:
                    {
                        genMaps.generateGrid(ACTIVELEVEL);
                        break;
                    }
                case 1:
                    {
                        genMaps.generateGrid(ACTIVELEVEL);
                        break;
                    }
                case 2:
                    {
                        genMaps.generateGrid(ACTIVELEVEL);
                        break;
                    }
                case 3:
                    {
                        genMaps.generateGrid(ACTIVELEVEL);
                        break;
                    }
                case 4:
                    {
                        genMaps.generateGrid(ACTIVELEVEL);
                        break;
                    }
                case 5:
                    {
                        genMaps.generateGrid(ACTIVELEVEL);
                        break;
                    }
            }
        }
        //TODO:: IMPLEMENT MOUSE INTERACTIONS
        //Process mouse location and possible clicks.
        public void CheckMouseInput(MouseState k)
        {
            gameObj.currMousePositionFunc.X = k.X;
            gameObj.currMousePositionFunc.Y = k.Y;
            if (k.LeftButton == ButtonState.Pressed)
            {
                //Will need to check all bounding boxes to see if a collision has occured between item boxes and the 
                //current mouse position.
            }
        }
        //TODO Fix Bug's in JUMP
        public void Jump(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.Space) && jumpState == false && !CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            {
                gameObj.currPlayerPositionFunc.Y -= 20;
                velocity.Y = -8f;
                jumpState = true;
            }
            if (jumpState == true && !CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            { 
                velocity.Y += 0.4f;
            }
            if (jumpState == true && CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            {
                velocity.Y += 0.4f;
            }
            if (jumpState == false && velocity.Y == 0 && CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            {
                gameObj.currPlayerPositionFunc.Y -= 2;
            }
            /*
            if(velocity.Y == 0 && jumpState == false && !CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            {
                velocity.Y += 0.4f;
            }
            */
            if (gameObj.currPlayerPositionFunc.Y > graphics.PreferredBackBufferHeight)
            {
                gameObj.currPlayerPositionFunc.Y = graphics.PreferredBackBufferHeight - 1;
                jumpState = false;
                velocity.Y = 0;
            }
        }
        //All Keyboard input will be processed here
        public void CheckKeyBoardInput(KeyboardState k,GameTime gameTime)
        {
            IDOWN = false;
            //End Game Case
            if (k.IsKeyDown(Keys.Escape) )
            {
                gameObj.Exit();
            }               
            //Right Movement Controlled By D
            else if (k.IsKeyDown(Keys.D) && !CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X + 5, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;
            }        
            //Left Movement Controlled by A
            else if (k.IsKeyDown(Keys.A) && !CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X - 5,gameObj.currPlayerPositionFunc.Y - 40,40,40)))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;          
            }
            else
            {
                velocity.X = 0f;
            }
            //Checks for jump keypress
            Jump(k);
            if(jumpState == false && !CollisionDetection(new Rectangle(gameObj.currPlayerPositionFunc.X - 5, gameObj.currPlayerPositionFunc.Y - 40, 40, 40)))
            {
                velocity.Y += .4f;
            }
                //TODO: OPEN INVENTORY SPRITE SCREEN(LOAD TO FRAME)
                //TODO  Find a good way to implement this functionality
                if (k.IsKeyDown(Keys.I))
            {
                IDOWN = true;
            }
            
            if (gameObj.currPlayerPositionFunc.Y < 0)
            {
                velocity.Y = 1f;
            }           
            //Check if we need to load a lower level
            if (gameObj.currPlayerPositionFunc.X <= 0)
            {
                if (ACTIVELEVEL != 0)
                {
                    ACTIVELEVEL -= 1;
                    loadLevel();
                    gameObj.currPlayerPositionFunc.X = (graphics.PreferredBackBufferWidth - ZONEOFFSET);
                }
            }
            //Check if we need to load a higher level
            if (gameObj.currPlayerPositionFunc.X >= graphics.PreferredBackBufferWidth)
            {
                if (ACTIVELEVEL != 5)
                {
                    ACTIVELEVEL += 1;
                    loadLevel();
                }
            }
        }
        //Handleded by movement processing
        public bool CollisionDetection(Rectangle r1)
        {

            //Blocking Action
            foreach (CollisionTile tile in genMaps.CollisionTile)
            {
                if (tile.Box.Intersects(r1))
                {
                    jumpState = false;
                    velocity.Y = 0;
                    return true;
                }
            }
            foreach (PlatForm tile in genMaps.PlatFormTile)
            {
                if (tile.Box.Intersects(r1))
                {
                    
                    jumpState = false;
                    velocity.Y = 0;
                    return true;
                }
            }
            
            foreach (ItemTile tile in genMaps.ItemTile.ToList())
            {
                if (tile.Box.Intersects(new Rectangle(gameObj.currPlayerPositionFunc.X, gameObj.currPlayerPositionFunc.Y, 40, 40)))
                {
                    Console.WriteLine("REMOVED");
                    genMaps.ItemTile.Remove(tile);
                }
            }
            
            return false;
        }  
    }
}
