using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Square
    {
        private Texture2D _squareTexture;

        private Point _position;
        private Point _size;

        private SquareState _currentState;

        public enum SquareState
        {
            EMPTY,
            ENEMY,
            FIENDLY,
            SELECTED
        }

        public Square(Point position, Point size, ContentManager content, SquareState state)
        {
            _position = position;
            _size = size;
            _currentState = state;

            _squareTexture = content.Load<Texture2D>("checkerBoard");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_squareTexture, _position.ToVector2(), null, Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            switch (_currentState)
            {
                case SquareState.EMPTY:
                    spriteBatch.Draw(_squareTexture, new Rectangle(_position, _size), Color.White);
                    break;
                case SquareState.SELECTED:
                    spriteBatch.Draw(_squareTexture, new Rectangle(_position, _size), Color.Blue);
                    break;
                case SquareState.ENEMY:
                    spriteBatch.Draw(_squareTexture, new Rectangle(_position, _size), Color.Red);
                    break;
            }
        }

        public Rectangle BoundingRectangle
        {
            get { return new Rectangle(_position, _size); }
        }

        public void SetPosition(Point position)
        {
            _position = position;
        }

        public Point GetPosition()
        {
            return _position;
        }

        public void SetState(SquareState state)
        {
            _currentState = state;
        }
    }
}
