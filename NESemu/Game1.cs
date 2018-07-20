using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Layers;
using Camera;

namespace NESemu
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        LayerManager lm;
        CameraManager c;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;
            IsFixedTimeStep = true;
            Content.RootDirectory = "Content";
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            c = new CameraManager(GraphicsDevice, 300, 1);
            lm = new LayerManager(GraphicsDevice, c);
            lm.addLayer(0);
            lm.getLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 0, 0);
            lm.addLayer(-1);
            lm.getLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 25, 25);
            lm.addLayer(1);
            lm.getLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 50, 50);
            lm.addLayer(2);
            lm.getLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 75, 75);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            c.applyKeyState(Keyboard.GetState());
            GraphicsDevice.Clear(Color.CornflowerBlue);
            lm.draw(c);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
