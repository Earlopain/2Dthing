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
            this.Camera = new CameraManager(graphicsDevice, 0, 1);
            this.Content = content;
            this.LayerManager = LevelParser.LoadLevel("test", graphicsDevice, content);
        }

        public void Draw()
        {
            LayerManager.Draw(Camera);
            return;
        }

        public void ApplyKeyState(KeyboardState keyState)
        {
            Camera.ApplyKeyState(keyState);
        }

    }
}