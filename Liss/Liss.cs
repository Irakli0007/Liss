using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Liss
{

    public class Liss : Game
    {
        private GraphicsDeviceManager graphics;
        //private SpriteBatch worldLayer;
        //private SpriteBatch baseLayer;
        //private SpriteBatch bottomLayer;
        private SpriteBatch final;
        private List<SpriteBatch> layers;
        private RenderTarget2D target;
        private Screen screen;

        public Liss()
        {
            graphics = new GraphicsDeviceManager(this);   
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            screen = new Screen(Content, graphics, GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //worldLayer = new SpriteBatch(GraphicsDevice);
            //baseLayer = new SpriteBatch(GraphicsDevice);
            //bottomLayer = new SpriteBatch(GraphicsDevice);
            //layers = new List<SpriteBatch>();
            //layers.Add(bottomLayer);
            //layers.Add(baseLayer);
            //layers.Add(worldLayer);
            final = new SpriteBatch(GraphicsDevice);

            target = new RenderTarget2D(GraphicsDevice, 1024, 576); // set scale here
            // other resolutions 640x360, 768x432, 1024x576, 1280x720
            // best ones for 16x16 pixel art seems like 768x432 or 1024x576

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            screen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            List<Tile[,]> tiles = screen.GetTiles();

            // draw to render target
            GraphicsDevice.SetRenderTarget(target);

            final.Begin();
            GraphicsDevice.Clear(Color.White);
            foreach (Tile[,] tileMap in tiles)
            {
                foreach (Tile t in tileMap)
                {
                    if (t.GetTexture() != null)
                    {
                        final.Draw(t.GetTexture(), t.GetLocation(), Color.White);
                    } 
                }
            }
            final.Draw(screen.GetPlayer().GetTexture(), screen.GetPlayer().GetLocation(), Color.White);
            final.End();

            //// draw to screen
            GraphicsDevice.SetRenderTarget(null);
            final.Begin();
            final.Draw(target, new Rectangle(0, 0, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height), Color.White);
            final.End();

            base.Draw(gameTime);
        }
    }
}
