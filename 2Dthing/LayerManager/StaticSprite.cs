using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

using Camera;

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

        public void Draw(SpriteBatch spriteBatch, Rectangle area, CameraManager camera)
        {
            //area not fully inside camera view, cut of the rest
            if (!camera.DrawArea.Contains(area))
            {
                DrawInformation drawInformation = new DrawInformation(area, camera.DrawArea);
                spriteBatch.Draw(Texture, drawInformation.DrawLocation, drawInformation.TexturePart, Color.White);
                return;
            }
            spriteBatch.Draw(Texture, area, Color.White);

        }
    }
}