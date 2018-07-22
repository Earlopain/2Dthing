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

        public GameStateManager(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.LayerManager = new LayerManager(graphicsDevice, content);
            this.Camera = new CameraManager(graphicsDevice, 300, 1);
            this.Content = content;
            this.LayerManager = LevelParser.LoadLevel("test", graphicsDevice, content);
            Camera.MoveTo(new Point(-LayerManager.Player.Position.X, -LayerManager.Player.Position.Y));
        }

        public void Draw()
        {
            LayerManager.Draw(Camera);
            return;
        }

        public void ApplyUserInput(KeyboardState keyboardState, MouseState mouseState)
        {
            Camera.ApplyUserInput(keyboardState, mouseState);
            LayerManager.Player.ApplyUserInput(keyboardState, mouseState);
        }

    }
}