using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using SciFiWest.Functionality;

namespace Game1
{
    public class Robot
    {
        Model model;

        float angle;
        float acceleration;

        private KeyboardState oldState;

        public void Initialize(ContentManager contentManager)
        {
            model = contentManager.Load<Model>("robot");
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Left)) //oldState.IsKeyUp(Keys.Left) && 
            {
                angle += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (newState.IsKeyDown(Keys.Right))
            {
                angle -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (newState.IsKeyDown(Keys.Up))
            {
                acceleration -= ((float)gameTime.ElapsedGameTime.TotalSeconds * 4);
            }

            if (newState.IsKeyDown(Keys.Down))
            {
                acceleration += ((float)gameTime.ElapsedGameTime.TotalSeconds * 4);
            }

            oldState = newState;

            // Keys[] pressedKeys = state.GetPressedKeys();

            //angle += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        // For now we'll take these values in, eventually we'll
        // take a Camera object
        public void Draw(GridCamera camera)
        {
            foreach (var mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;

                    effect.World = GetWorldMatrix();
                    effect.View = camera.ViewMatrix;
                    effect.Projection = camera.ProjectionMatrix;
                }

                mesh.Draw();
            }
        }

        Matrix GetWorldMatrix()
        {
            const float circleRadius = 8;
            const float heightOffGround = 3;

            //Math.Sin(acceleration);
            float sin = (float)Math.Sin(angle) * acceleration;
            //float cos = (float)Math.Cos(angle);

            Matrix translationMatrix = Matrix.CreateTranslation(sin, sin, heightOffGround);

            Matrix rotationMatrix = Matrix.CreateRotationZ(angle);

            //Matrix combined = translationMatrix * rotationMatrix;
            Matrix combined = rotationMatrix * translationMatrix;

            return combined;
        }
    }
}
