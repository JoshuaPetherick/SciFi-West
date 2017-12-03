using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using SciFiWest.Objects;
using SciFiWest.Containers;
using SciFiWest.Functionality;

namespace SciFiWest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SciFiWest : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Bot bot;
        Zone currZone;
        WorldCamera camera;

        public SciFiWest()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new WorldCamera(GraphicsDevice.Viewport);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.Load(Content);
            // TODO: use this.Content to load your game content here
            currZone = new Zone(0);
            bot = new Bot(0,0,30,50);
            // Starting Camera Position
            //camera.Position = new Vector2(-375, -340);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            int wDist = bot.getWidth()*8;
            int hDist = bot.getHeight()*8;
            int widthDist = (Window.ClientBounds.Width - (bot.getWidth())) - wDist;
            int heightDist = (Window.ClientBounds.Height - (bot.getHeight())) - hDist;
            int zoneWDist = ((currZone.x + currZone.width) - Window.ClientBounds.Width);
            int zoneHDist = ((currZone.y + currZone.height) - Window.ClientBounds.Height);
            // Updates
            bot.Update(gameTime, Window);            
            // Camera logic
            // X
            if (bot.getX() > (camera.Position.X + widthDist)) camera.Position = new Vector2((bot.getX() - widthDist), camera.Position.Y);
            if (bot.getX() < (camera.Position.X + wDist)) camera.Position = new Vector2((bot.getX() - wDist), camera.Position.Y);
            // Y
            if (bot.getY() > (camera.Position.Y + heightDist)) camera.Position = new Vector2(camera.Position.X, (bot.getY() - heightDist));
            if (bot.getY() < (camera.Position.Y + hDist)) camera.Position = new Vector2(camera.Position.X, (bot.getY() - hDist));
            // Catch to make sure position doesn't move outside Zone bounds
            if (camera.Position.X < currZone.x) camera.Position = new Vector2(currZone.x, camera.Position.Y);
            else if (camera.Position.X > zoneWDist) camera.Position = new Vector2(zoneWDist, camera.Position.Y);
            if (camera.Position.Y < currZone.y) camera.Position = new Vector2(camera.Position.X, currZone.y);
            else if (camera.Position.Y > zoneHDist) camera.Position = new Vector2(camera.Position.X, zoneHDist);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Matrix viewMatix = camera.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: viewMatix);
            //spriteBatch.Begin();

            currZone.drawBackground(spriteBatch);
            // Enemies
            bot.draw(spriteBatch);
            currZone.drawForeground(spriteBatch);
            // UI

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

    // ** Grid code

    // Grid Initialize
    //Point startPosition = new Point(40, 40);
    //Point squareSize = new Point(50, 50);

    //for (int i = 0; i < _squareGrid.GetLength(0); i++)
    //{
    //    for (int j = 0; j < _squareGrid.GetLength(1); j++)
    //    {
    //        int x = squareSize.X * i + startPosition.X;
    //        int y = squareSize.Y * j + startPosition.Y;

    //        _squareGrid[i, j] = new Square(new Point(x, y), squareSize, Content, Square.SquareState.EMPTY);
    //    }
    //}

    //_squareGrid[3, 1].SetState(Square.SquareState.ENEMY);
    //_squareGrid[3, 4].SetState(Square.SquareState.ENEMY);


    // Grid Update
    //MouseState mouseState = Mouse.GetState();

    //if (mouseState.LeftButton == ButtonState.Pressed)
    //{
    //    foreach (Square s in _squareGrid)
    //    {
    //        if (s.BoundingRectangle.Contains(mouseState.Position))
    //        {
    //            if (_selectSquare != null) _selectSquare.SetState(Square.SquareState.EMPTY);

    //            _selectSquare = s;
    //            s.SetState(Square.SquareState.SELECTED);
    //        }
    //    }
    //}

    // Grid Draw
    //foreach (Square s in _squareGrid)
    //{
    //    s.Draw(_spriteBatch);
    //}

}
