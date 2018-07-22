using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Camera;

namespace Sprites
{
    public interface ISpriteInterface
    {
        Texture2D Texture { get; }
        Point Position { get; }
        int Rows { get; }
        int Columns { get; }
        void Draw(SpriteBatch spriteBatch, Rectangle area, CameraManager camera);
    }
}