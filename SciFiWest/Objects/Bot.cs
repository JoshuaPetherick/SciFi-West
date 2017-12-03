using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using SciFiWest.Functionality;

namespace SciFiWest.Objects
{
    public class Bot
    {
        // Base Properties
        private Texture2D texture;
        private int x;
        private int y;
        private int width;
        private int height;
        // Additional Properties
        private int speed = 2;

        public Bot(int x, int y, int width, int height)
        {
            texture = TextureManager.charPlayerTexture;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }

        public void Update(GameTime gameTime, GameWindow window)
        {
            // Up
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                y -= speed;
            }
            // Left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                x -= speed;
            }
            // Down
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                y += speed;
            }
            // Right
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                x += speed;
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, width, height), Color.GhostWhite);
        }
    }
}
