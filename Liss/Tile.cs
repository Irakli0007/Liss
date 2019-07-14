using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liss
{
    class Tile
    {
        private readonly ContentManager content;
        private readonly GraphicsDevice graphicsDevice;

        private TileTypes type;
        private Texture2D texture;
        private readonly int tileNum;
        private static int tileSize = 16;
        private Point p;

        public Tile(int num, Point p, ContentManager content, GraphicsDevice gd)
        {
            tileNum = num;
            this.p = p;
            this.content = content;
            graphicsDevice = gd;
            SetData();
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public TileTypes GetTileType()
        {
            return type;
        }

        public Vector2 GetLocation()
        {
            int x = p.X * tileSize;
            int y = p.Y * tileSize;
            return new Vector2(x, y);
        }

        private void SetData()
        {
            int x = tileNum % 6;
            int y = tileNum / 6;
            Rectangle rect = new Rectangle(tileSize * x, tileSize * y, tileSize, tileSize);
            Color[] data = new Color[rect.Width * rect.Height];
            content.Load<Texture2D>("OutdoorsTileset").GetData(0, rect, data, 0, data.Length);
            Texture2D newTexture = new Texture2D(graphicsDevice, tileSize, tileSize);
            newTexture.SetData(data);
            texture = newTexture;
            type = (TileTypes)tileNum;
        }

    }
}
