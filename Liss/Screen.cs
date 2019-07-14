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
        private string[,] map;
        private Tile[,] tiles;
        private Player player;

        public Screen(ContentManager content, GraphicsDeviceManager graphics, GraphicsDevice gd)
        {
            this.content = content;
            this.graphics = graphics;
            graphicsDevice = gd;
            map = new string[20, 20];
            tiles = new Tile[20, 20];
            LoadMap();
            CreateTiles();
            player = new Player(content, graphicsDevice); 
    }

        public Tile[,] GetTiles()
        {
            return tiles;
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

        private void LoadMap()
        {
            string text = File.ReadAllText("Content/testmap.csv").Replace(System.Environment.NewLine, ",");
            string[] vals = text.Split(',');
            int count = 0;
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    map[j, i] = vals[count];
                    count++;
                }
            }
        }

        private void CreateTiles()
        {
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    int num = Int32.Parse(map[j, i]);
                    Point p = new Point(j, i);
                    Tile t = new Tile(num, p, content, graphicsDevice);
                    tiles[j, i] = t;
                }
            }
        }
    }
}
