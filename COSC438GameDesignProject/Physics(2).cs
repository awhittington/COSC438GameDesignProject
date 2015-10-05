using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;
namespace COSC438GameDesignProject
{
    class Physics
    {
        const int MAPSIZE = 240;
        MouseState checkMouseState;
        KeyboardState checKeyBoardState;
        SpriteBatch sprites;
        GraphicsDeviceManager graphics;
        int playerXPos, playerYPos, characterNum;
        //Jump Height is 80 Pixels;
        Game1 gameObj;
        Dictionary<int, Tuple<int, Texture2D, bool>> inventoryContainer;
        //TODO Determine all parameters needed to spawn a physics class with functionality.
        public Physics(Game1 gameObj, int playerXPos, int playerYPos, int characterNum, SpriteBatch sprites, GraphicsDeviceManager graphics)
        {
            this.inventoryContainer = new Dictionary<int, Tuple<int, Texture2D, bool>>();
            this.gameObj = gameObj;
            this.playerXPos = playerXPos;
            this.playerYPos = playerYPos;
            this.characterNum = characterNum;
            this.sprites = sprites;
            this.graphics = graphics;
        }
        //Handleded by movement processing
        public bool WallDetection()
        {
            for (int x = 0; x < MAPSIZE; x++)
            {
                //Blocking Action
                if (( gameObj.spriteContainerFunc.ContainsKey(x) &&  (gameObj.spriteContainerFunc[x].Item1 == 2) )&& gameObj.spriteContainerFunc[x].Item3.Intersects(new Rectangle(playerXPos + 20, playerYPos - 20, 40, 40)))
                { 
                    return true;
                }
            }
            return false;
        }
        
        //Call from game on physics object
        public void  ItemDetection()
        {
            for (int x = 0; x < MAPSIZE; x++)
            {
                Console.WriteLine();
                //Found Interactive Location that has a value corresponding to an item
                if (gameObj.spriteContainerFunc.ContainsKey(x)  && gameObj.spriteContainerFunc[x].Item3.Intersects(new Rectangle(playerXPos + 20, playerYPos - 20, 40, 40)))
                {
                    gameObj.spriteContainerFunc.Remove(x);
                }
            }
        }
        public void ProcessInputFunctions(MouseState mouseState, KeyboardState keyBoardState)
        {
            //capture mouse state
            this.checkMouseState = mouseState;
            //Process mouse state
            CheckMouseInput(checkMouseState);
            //Capture the keyboard state
            this.checKeyBoardState = keyBoardState;
            //Process keyboard state
            CheckKeyBoardInput(checKeyBoardState);
        }
        //Process mouse location and possible clicks.
        public void CheckMouseInput(MouseState k)
        {
            gameObj.mouseXFunc = k.X;
            gameObj.mouseYFunc = k.Y;
            if (k.LeftButton == ButtonState.Pressed)
            {
                //Will need to check all bounding boxes to see if a collision has occured between item boxes and the 
                //current mouse position.
            }
        }
        //All Keyboard input will be processed here
        public void CheckKeyBoardInput(KeyboardState k)
        {
            //End Game Case
            if (k.IsKeyDown(Keys.Escape) && !WallDetection())
            {
                gameObj.Exit();
            }
            //Upward Movement Controlled By W
            if (k.IsKeyDown(Keys.W) && !WallDetection())
            {       
                gameObj.playerYPOSFunc = playerYPos -= 5;
            }
            //Downward Movement Controlled by S
            if (k.IsKeyDown(Keys.S) && gameObj.playerYPOSFunc < graphics.PreferredBackBufferHeight && !WallDetection())
            {
                gameObj.playerYPOSFunc = playerYPos += 5;
            }
            //Right Movement Controlled By D
            if (k.IsKeyDown(Keys.D) && gameObj.playerXPOSFunc < graphics.PreferredBackBufferWidth && !WallDetection())
            {
                gameObj.playerXPOSFunc = playerXPos += 5;
            }
            //Left Movement Controlled by A
            if (k.IsKeyDown(Keys.A) && gameObj.playerXPOSFunc > 0 && !WallDetection())
            {
                gameObj.playerXPOSFunc = playerXPos -= 5;
            }
            //TODO: OPEN INVENTORY SPRITE SCREEN(LOAD TO FRAME)
            //TODO  Find a good way to implement this functionality
            if (k.IsKeyDown(Keys.I))
            {
                sprites.Begin();
                sprites.Draw(gameObj.getINV, new Rectangle(250, graphics.PreferredBackBufferHeight - gameObj.getINV.Height, gameObj.getINV.Width, gameObj.getINV.Height), Color.White);
                sprites.End();
            }
            //TODO ADD JUMP FUNCTIONALITY
            //TODO Determine if we are allowing characters to move up, or invoking gravity.
            if (k.IsKeyDown(Keys.Space))
            {
                // playerXPOS -= 5;
            }
        }
    }
}
