using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

using Camera;
using Layers;
using Level;

namespace GameState
{
    public class GameStateManager
    {
        CameraManager Camera;
        LayerManager LayerManager;
        ContentManager Content;
        /// <summary>
        /// Manages all things 
        /// </summary>
        /// <param name="graphicsDevice">Used to draw</param>
        /// <param name="content">Used to load content</param>
        public GameStateManager(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.LayerManager = new LayerManager(graphicsDevice, content);
            this.Camera = new CameraManager(graphicsDevice, 300, 1);
            this.Content = content;
            this.LayerManager = LevelParser.LoadLevel("test", graphicsDevice, content);
            //Centers the camera around the player
            Camera.MoveTo(new Point(-LayerManager.Player.Position.X, -LayerManager.Player.Position.Y));
        }

        public void Draw()
        {
            LayerManager.Draw(Camera);
        }

        public void ApplyUserInput(KeyboardState keyboardState, MouseState mouseState)
        {
            Camera.ApplyUserInput(keyboardState, mouseState);
            LayerManager.Player.ApplyUserInput(keyboardState, mouseState);
        }

    }
}