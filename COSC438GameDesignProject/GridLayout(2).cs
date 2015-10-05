using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace COSC438GameDesignProject
{
    class GridLayout
    {
        //All Levels Standardized to 800W, 400H
        //Each grid will be 50x50 AKA 16Cols,8Rows
        Rectangle[] gridBoxes = new Rectangle[240];
        private Dictionary<int, Tuple<int, Texture2D, Rectangle>> spriteContainer;
        public Dictionary<int, Tuple<int, Texture2D, Rectangle>> spriteContainerGetter()
        {      
                return spriteContainer;         
        }
        MapContainer getMap = new MapContainer();
        private Texture2D Item1;
        private Texture2D boundingBoxImg;
        private Texture2D Item2;
        Game1 gameObj;
        public GridLayout(Game1 gameObj)
        {
            this.gameObj = gameObj;
        }
        //After grid for level is constructed, game1.cs "should" call this getter to recieve all bounding boxes that are relevant to the map.
        public void generateGrid(int levelNum)
        {
            switch (levelNum)
            {
                case 1:
                    populateGrid(getMap.levelOne);
                    break;
                case 2:
                    populateGrid(getMap.levelTwo);
                    break;
                case 3:
                    populateGrid(getMap.levelThree);
                    break;
                case 4:
                    populateGrid(getMap.levelFour);
                    break;
                case 5:
                    populateGrid(getMap.levelFive);
                    break;
            }
        }
        public void populateGrid(int[,] tempArr)
        {
            spriteContainer = new Dictionary<int, Tuple<int, Texture2D, Rectangle>>();
            boundingBoxImg = Texture2D.FromStream(gameObj.GraphicsDevice, TitleContainer.OpenStream(@"Images/B.png"));
            Item1 = Texture2D.FromStream(gameObj.GraphicsDevice, TitleContainer.OpenStream(@"Images/I1.png"));
            Item2 = Texture2D.FromStream(gameObj.GraphicsDevice, TitleContainer.OpenStream(@"Images/I2.png"));
            int startY = 0;
            int count = 0;
            int startX = 0;
            int x, y;
            for (x = 0; x < tempArr.GetLength(0); x++)
            {
                for (y = 0; y < tempArr.GetLength(1); y++)
                {
                    switch (tempArr[x, y])
                    {
                        case 1:
                            {                              
                                //Check for elements that matter in our map, if we find a location that matters we are going to add a rectangle to that location.                               
                                spriteContainer.Add(count, Tuple.Create(1, boundingBoxImg, new Rectangle(startX,startY,boundingBoxImg.Width,boundingBoxImg.Height)));
                                gridBoxes[count] = new Rectangle(startX, startY, 40, 40);
                                startX += 40;
                                break;
                            }
                        case 2:
                            {
                                //Check for elements that matter in our map, if we find a location that matters we are going to add a rectangle to that location.
                                spriteContainer.Add(count, Tuple.Create(2, boundingBoxImg, new Rectangle(startX, startY, boundingBoxImg.Width, boundingBoxImg.Height)));
                                gridBoxes[count] = new Rectangle(startX, startY, 40, 40);          
                                startX += 40;
                                break;
                            }
                        case 3:
                            {
                                spriteContainer.Add(count, Tuple.Create(3, boundingBoxImg, new Rectangle(startX, startY, boundingBoxImg.Width, boundingBoxImg.Height)));
                                gridBoxes[count] = new Rectangle(startX, startY, 40, 40);                          
                                startX += 40;
                                break;
                            }
                        case 4:
                            {
                                spriteContainer.Add(count, Tuple.Create(4, Item1, new Rectangle(startX, startY, Item1.Width, Item1.Height)));
                                gridBoxes[count] = new Rectangle(startX, startY, 40, 40);
                                startX += 40;
                                break;
                            }
                        case 5:
                            {
                                spriteContainer.Add(count, Tuple.Create(5, Item2, new Rectangle(startX, startY, Item2.Width, Item2.Height)));
                                gridBoxes[count] = new Rectangle(startX, startY, 40, 40);
                                startX += 40;
                                break;
                            }
                        default:
                            {
                                startX += 40;
                                break;
                            }
                    }
                    count++;
                }
                startY += 40;
                startX = 0;
            }
        }
    }
}
