using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprites
{
    public class StaticSprite : ISpriteInterface
    {
        public Texture2D Texture { get; }
        public Point Position { get; }
        public int Rows { get; }
        public int Columns { get; }
        public StaticSprite(Texture2D texture, Point p)
        {
            this.Texture = texture;
            this.Position = p;
            this.Rows = 1;
            this.Columns = 1;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle area)
        {
            spriteBatch.Draw(Texture, area, Color.White);
        }
    }
}