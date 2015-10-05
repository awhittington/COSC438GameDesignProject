using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace COSC438GameDesignProject
{
    class MapContainer
    {
        public Dictionary<int, Tuple<int, Texture2D, Rectangle>> STATICSPRITES;
        public MapContainer(Game1 game)
        {
            GraphicsDevice gd = game.GraphicsDevice;
            GraphicsDeviceManager gdm = game.graphicsFunc;
            STATICSPRITES = new Dictionary<int, Tuple<int, Texture2D, Rectangle>>();         
            //IMPORTANT:: load sprites in in the order you want to be displayed if they overlap. NOTE:: Key value maps to order of loading, First INT value in tuple is for knowing the prpose of each sprite
            //I.E Sprite Containing tuple value 0 should map to level zero, all static elements that will be drawn regardless of map will be given value -1.
            STATICSPRITES.Add(0, Tuple.Create(-1, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/background.jpg")), new Rectangle(0, 0, 800, 480)));
            STATICSPRITES.Add(1, Tuple.Create(-1, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/Up.png")), new Rectangle(gdm.PreferredBackBufferWidth - 10, gdm.PreferredBackBufferHeight - 100, 10, 100)));
            STATICSPRITES.Add(2, Tuple.Create(-1, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/Down.png")), new Rectangle(0, gdm.PreferredBackBufferHeight - 100, 10, 100)));
            STATICSPRITES.Add(3, Tuple.Create(-1, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/CaveTop.png")), new Rectangle(0, gdm.PreferredBackBufferHeight - 100, 10, 100)));
            STATICSPRITES.Add(4, Tuple.Create(0, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/LVL0.png")), new Rectangle(( gdm.PreferredBackBufferWidth / 2) - 100, 0, 200, 150)));
            STATICSPRITES.Add(5, Tuple.Create(1, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/Lvl1.png")), new Rectangle((gdm.PreferredBackBufferWidth / 2) - 100, 0, 200, 150)));
            STATICSPRITES.Add(6, Tuple.Create(2, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/LvL2.png")), new Rectangle((gdm.PreferredBackBufferWidth / 2) - 100, 0, 200, 150)));
            STATICSPRITES.Add(7, Tuple.Create(3, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/LVL3.png")), new Rectangle((gdm.PreferredBackBufferWidth / 2) - 100, 0, 200, 150)));
            STATICSPRITES.Add(8, Tuple.Create(4, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/LVL4.png")), new Rectangle((gdm.PreferredBackBufferWidth / 2) - 100, 0, 200, 150)));
            STATICSPRITES.Add(9, Tuple.Create(5, Texture2D.FromStream(gd, TitleContainer.OpenStream(@"Images/LVL5.png")), new Rectangle((gdm.PreferredBackBufferWidth / 2) - 100, 0, 200, 150)));
            game.STATICSPRITESFunc = STATICSPRITES;
        }                
        public int[,] levelZero = new int[,]
                          {{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0},
                           { 0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        public  int[,] levelOne = new int[,]
                          {{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,2,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0},
                           { 0,0,3,3,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,2,0,0,0,0,1,1,0,0,0,0,0,0,0}};
        public int[,] levelTwo = new int[,]
                          {{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,1,1,0,0,0,0,1,1,1,1,1,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        public int[,] levelThree = new int[,]
                        {{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        public int[,] levelFour = new int[,]
                           {{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        public int[,] levelFive = new int[,]
                           {{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        
    }
}
