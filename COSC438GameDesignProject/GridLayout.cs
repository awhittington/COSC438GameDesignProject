using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace COSC438GameDesignProject
{
    public class GridLayout
    {
        private const int SIZE = 40;
        //All Levels Standardized to 800W, 400H
        //Each grid will be 40x40 AKA 20Cols,12Rows
        private List<CollisionTile> collisonTile;
        private List<Generic> genericTile;
        private List<ItemTile> itemTile;
        private List<PlatForm> platFormTile;
        private Game1 gameObj;
        public List<CollisionTile> CollisionTile
        {
            get
            {
                return collisonTile;
            }
            set
            {
                collisonTile = value;
            }
       }
        public void ClearTiles()
        {
            collisonTile.Clear();
            genericTile.Clear();
            itemTile.Clear();
            platFormTile.Clear();
        }
        public List<Generic> GenericTile
        {
            get
            {
                return genericTile;
            }
            set
            {
                genericTile = value;
            }
        }
        public List<ItemTile> ItemTile
        {
            get
            {
                return itemTile;
            }
            set
            {
                itemTile = value;
            }
        }
        public List<PlatForm> PlatFormTile
        {
            get
            {
                return platFormTile;
            }
            set
            {
                platFormTile = value;
            }
        }
        public GridLayout(Game1 gameObj)
        {
            this.gameObj = gameObj;
        }
        public void generateGrid(int levelNum)
        {        
            gameObj.spriteContainerFunc = new Dictionary<int, Tuple<int, Texture2D, Rectangle>>();
            MapContainer getMap = new MapContainer(gameObj);
            this.collisonTile = new List<CollisionTile>();
            this.genericTile = new List<Generic>();
            this.itemTile = new List<ItemTile>();
            this.platFormTile = new List<PlatForm>();
            switch (levelNum)
            {
                case 0:
                    {
                        populateGrid(getMap.levelZero);
                        break;
                    }
                case 1:
                    {
                        populateGrid(getMap.levelOne);
                        break;
                    }
                case 2:
                    {
                        populateGrid(getMap.levelTwo);
                        break;
                    }
                case 3:
                    {
                        populateGrid(getMap.levelThree);
                        break;
                    }
                case 4:
                    {
                        populateGrid(getMap.levelFour);
                        break;
                    }
                case 5:
                    {
                        populateGrid(getMap.levelFive);
                        break;
                    }
            }
        }
        public void populateGrid(int[,] tempArr)
        {          
            //If all sprites are going to be individually indexed we can streamline their implementation in a data structure.
            //TODO ^ Determine Structure.           
            int x, y;
            for (x = 0; x < tempArr.GetLength(1); x++)
            {
                for (y = 0; y < tempArr.GetLength(0); y++)
                {
                    switch (tempArr[y, x])
                    {
                        case 0:
                            {
                                //Slow loading when adding generic tiles
                             // GenericTile.Add(new Generic(0, new Rectangle(x * SIZE, y * SIZE, SIZE, SIZE), gameObj));
                                break;
                            }
                        case 1:
                            {
                                collisonTile.Add(new CollisionTile(1, new Rectangle(x * SIZE, y * SIZE, SIZE, SIZE),gameObj));                                                                                                                                                 
                                break;
                            }
                        case 2:
                            {
                                itemTile.Add(new ItemTile(2, new Rectangle(x * SIZE, y * SIZE, SIZE, SIZE),gameObj));
                                break;
                            }
                        case 3:
                            {
                                platFormTile.Add(new PlatForm(3, new Rectangle(x * SIZE, y * SIZE, SIZE, SIZE), gameObj));
                                break;
                            }             
                    }
                }
            }
         
        }
       
    }
}
