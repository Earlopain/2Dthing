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
        GraphicsDeviceManager Graphics;
        LayerManager LayerManager;
        CameraManager Camera;

        public Game1()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Graphics.IsFullScreen = true;
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
            this.Camera = new CameraManager(GraphicsDevice, 300, 1);
            this.LayerManager = new LayerManager(GraphicsDevice);
            LayerManager.getLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.getLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 25, 25);
            LayerManager.getLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 50, 50);
            LayerManager.getLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 75, 75);
            LayerManager.getLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 125, 125);
            LayerManager.getLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 150, 150);
            LayerManager.getLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 175, 175);
            LayerManager.getLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 200, 200);
            LayerManager.getLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 250, 250);
            LayerManager.getLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 300, 300);
            LayerManager.getLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 350, 350);
            LayerManager.getLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 400, 400);
            LayerManager.getLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 450, 450);
            LayerManager.getLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 500, 500);
            LayerManager.getLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 550, 550);
            LayerManager.getLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 600, 600);
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

            Camera.applyKeyState(Keyboard.GetState());

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //System.Console.WriteLine(1 / gameTime.ElapsedGameTime.TotalSeconds);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            LayerManager.draw(Camera);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
