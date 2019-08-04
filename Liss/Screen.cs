using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liss
{
    class Screen
    {
        private readonly ContentManager content;
        private readonly GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;
        private string[,] bottomMap;
        private string[,] baseMap;
        private string[,] worldMap;
        private Tile[,] bottomTiles;
        private Tile[,] baseTiles;
        private Tile[,] worldTiles;
        private List<Tile[,]> layers;
        private Player player;

        public Screen(ContentManager content, GraphicsDeviceManager graphics, GraphicsDevice gd)
        {
            this.content = content;
            this.graphics = graphics;
            graphicsDevice = gd;
            bottomMap = new string[55, 35];
            baseMap = new string[55, 35];
            worldMap = new string[55, 35];
            bottomTiles = new Tile[55, 35];
            baseTiles = new Tile[55, 35];
            worldTiles = new Tile[55, 35];
            layers = new List<Tile[,]>();
            LoadMaps();
            CreateTiles();
            player = new Player(content, graphicsDevice); 
        }

        public List<Tile[,]> GetTiles()
        {
            return layers;
        }

        public Tile GetTile(Point p)
        {
            Vector2 location = new Vector2(p.X * Tile.tileSize, p.Y * Tile.tileSize);
            foreach (Tile t in worldTiles)
            {
                if(t.GetLocation() == location)
                {
                    return t;
                }
            }
            return null;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void Update(GameTime gameTime)
        {
            // update logic for screen tiles
            player.Update(gameTime, graphics);

        }

        private void LoadMaps()
        {
            string text = File.ReadAllText("Content/TestTileMap_BottomLayer.csv").Replace(System.Environment.NewLine, ",");
            string[] vals = text.Split(',');
            int count = 0;
            for(int i = 0; i < 35; i++)
            {
                for(int j = 0; j < 55; j++)
                {
                    bottomMap[j, i] = vals[count];
                    count++;
                }
            }

            text = File.ReadAllText("Content/TestTileMap_BaseLayer.csv").Replace(System.Environment.NewLine, ",");
            vals = text.Split(',');
            count = 0;
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    baseMap[j, i] = vals[count];
                    count++;
                }
            }

            text = File.ReadAllText("Content/TestTileMap_World.csv").Replace(System.Environment.NewLine, ",");
            vals = text.Split(',');
            count = 0;
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    worldMap[j, i] = vals[count];
                    count++;
                }
            }
        }

        private void CreateTiles()
        {
            for(int i = 0; i < 35; i++)
            {
                for(int j = 0; j < 55; j++)
                {
                    int num = Int32.Parse(bottomMap[j, i]);
                    Point p = new Point(j, i);
                    Tile t = new Tile(num, p, content, graphicsDevice);
                    bottomTiles[j, i] = t;
                }
            }

            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    int num = Int32.Parse(baseMap[j, i]);
                    Point p = new Point(j, i);
                    Tile t = new Tile(num, p, content, graphicsDevice);
                    baseTiles[j, i] = t;
                }
            }

            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    int num = Int32.Parse(worldMap[j, i]);
                    Point p = new Point(j, i);
                    Tile t = new Tile(num, p, content, graphicsDevice);
                    worldTiles[j, i] = t;
                }
            }

            layers.Add(bottomTiles);
            layers.Add(baseTiles);
            layers.Add(worldTiles);
        }
    }
}
