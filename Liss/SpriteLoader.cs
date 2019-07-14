//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Liss
//{
//    class SpriteLoader
//    {
//        private List<Tile> tiles;
//        private Texture2D spriteSheet;
//        private readonly ContentManager content;
//        private readonly int spriteSize;
//        private readonly GraphicsDevice graphicsDevice;

//        public SpriteLoader(ContentManager content, int spriteSize, GraphicsDevice gd)
//        {
//            tiles = new List<Tile>();
//            this.content = content;
//            this.spriteSize = spriteSize;
//            graphicsDevice = gd;
//        }

//        public List<Tile> Init()
//        {
//            spriteSheet = content.Load<Texture2D>("OutdoorsTileset");
//            int x = spriteSheet.Width / spriteSize;
//            int y = spriteSheet.Height / spriteSize;
//            x = 6; // hardcoding for now
//            y = 3; // hardcoding for now

//            for (int i = 0; i < y; i++)
//            {
//                for (int j = 0; j < x; j++)
//                {
//                    Rectangle rect = new Rectangle(spriteSize * j, spriteSize * i, spriteSize, spriteSize);
//                    Color[] data = new Color[rect.Width * rect.Height];
//                    spriteSheet.GetData(0, rect, data, 0, data.Length);
//                    Texture2D newTexture = new Texture2D(graphicsDevice, spriteSize, spriteSize);
//                    newTexture.SetData(data);
//                    Tile t = new Tile(j, i, newTexture);
//                    tiles.Add(t);
//                }
//            }

//            return tiles;
//        }
//    }
//}
