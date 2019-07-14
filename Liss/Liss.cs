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
        private SpriteBatch spriteBatch;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            Tile[,] tiles = screen.GetTiles();

            // draw to render target
            GraphicsDevice.SetRenderTarget(target);
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            foreach (Tile t in tiles)
            {
                spriteBatch.Draw(t.GetTexture(), t.GetLocation(), Color.White);
            }
            spriteBatch.Draw(screen.GetPlayer().GetTexture(), screen.GetPlayer().GetLocation(), Color.White);
            spriteBatch.End();

            //// draw to screen
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin();
            spriteBatch.Draw(target, new Rectangle(0, 0, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
