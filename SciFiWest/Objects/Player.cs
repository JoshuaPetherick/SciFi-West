using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Player
    {
        public Texture2D _playerTexture;

        public Vector2 _position = new Vector2(50, 50);
        public float speed = 3;
        public Vector2 velocity;

        public void Initialize(ContentManager contentManager)
        {
            _playerTexture = contentManager.Load<Texture2D>("checkerBoard");
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            MouseState mouseState = Mouse.GetState();

            Vector2 mousePosition = new Vector2(mouseState.Position.X, mouseState.Position.Y);
            Vector2 direction = mousePosition - _position;
            float distance = CalculateDirection(mousePosition);
            velocity = Vector2.Zero;

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (distance < speed)
                {
                    velocity += direction * distance;
                }
                else
                {
                    velocity += direction * speed;
                }
            }

            _position += velocity;

            //if (newState.IsKeyDown(Keys.W)) //oldState.IsKeyUp(Keys.Left) && 
            //{
            //    _position.Y -= 1;
            //}

            //if (newState.IsKeyDown(Keys.S))
            //{
            //    _position.Y += 1;
            //}

            //if (newState.IsKeyDown(Keys.D))
            //{
            //    _position.X += 1;
            //}

            //if (newState.IsKeyDown(Keys.A))
            //{
            //    _position.X -= 1;
            //}
        }

        private float CalculateDirection(Vector2 mousePos)
        {
            mousePos = new Vector2(Math.Abs(mousePos.X), Math.Abs(mousePos.Y));
            _position = new Vector2(Math.Abs(_position.X), Math.Abs(_position.Y));

            float yDiff, xDiff, distance;

            yDiff = mousePos.Y - _position.Y;
            xDiff = mousePos.X - _position.X;

            distance = (float)Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));

            return Math.Abs(distance);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _position, null, Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
