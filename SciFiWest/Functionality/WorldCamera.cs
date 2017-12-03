using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SciFiWest.Functionality
{
    class WorldCamera
    {
        private readonly Viewport viewport;

        public WorldCamera(Viewport viewport)
        {
            this.viewport = viewport;

            Rotation = 0;
            Zoom = 1.0f;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Position { get; set; }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                    Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                    Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom, Zoom, 1) *
                    Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }
    }
}
