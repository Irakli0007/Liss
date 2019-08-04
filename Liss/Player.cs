using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liss
{
    class Player
    {
        private readonly ContentManager content;
        private readonly GraphicsDevice graphicsDevice;
        private Texture2D texture;
        private Vector2 playerPosition;
        private float playerSpeed;

        public Player(ContentManager content, GraphicsDevice gd)
        {
            this.content = content;
            graphicsDevice = gd;
            playerPosition.X = 250;
            playerPosition.Y = 250;
            playerSpeed = 100f;
            CreatePlayer();
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            KeyboardState kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            playerPosition.X = Math.Min(Math.Max(texture.Width / 2, playerPosition.X), graphics.PreferredBackBufferWidth - texture.Width / 2);
            playerPosition.Y = Math.Min(Math.Max(texture.Height / 2, playerPosition.Y), graphics.PreferredBackBufferHeight - texture.Height / 2);

        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public Vector2 GetLocation()
        {
            return playerPosition;
        }

        private void CreatePlayer()
        {
            Rectangle rect = new Rectangle(0, 0, 16, 21);
            Color[] data = new Color[rect.Width * rect.Height];
            content.Load<Texture2D>("trainer2sprites").GetData(0, rect, data, 0, data.Length);
            Texture2D newTexture = new Texture2D(graphicsDevice, 16, 21);
            newTexture.SetData(data);
            texture = newTexture;

        }

    }
}
