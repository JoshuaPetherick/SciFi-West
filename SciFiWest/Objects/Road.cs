using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SciFiWest.Functionality;

namespace SciFiWest.Objects
{
    class Road : Object
    {
        // Base Properties
        private Texture2D texture;
        private int x;
        private int y;
        private int width;
        private int height;

        public Road(int x, int y, int width, int height)
        {
            texture = TextureManager.zoneRoadTexture;
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


        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, width, height), Color.GhostWhite);
        }
    }
}
